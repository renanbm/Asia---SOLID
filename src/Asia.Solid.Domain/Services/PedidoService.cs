using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Runtime.InteropServices;
using Asia.Solid.Domain.Entities;
using System.Linq;
using System.Text;

namespace Asia.Solid.Domain.Services
{
    public class PedidoService
    {
        public IList<Produto> ProdutosIndisponiveis { get; set; }

        public void EfetuarPedido(Carrinho carrinho, DetalhePagamento detalhePagamento, bool notificarClienteEmail,
            bool notificarClienteSms)
        {
            if (VerificaDisponibilidade(carrinho)) {

                CalculaImposto(carrinho);

                if (EfetuaPagamento(carrinho, detalhePagamento))
                    TrataEstoque(carrinho);
                else
                    throw new ExternalException("O pagamento não foi efetuado.");

                NotificadorEmail(carrinho, notificarClienteEmail);

                NotificadorSMS(carrinho, notificarClienteSms);
            } else
            {
                var produtosIndisponiveis = ProdutosIndisponiveis.Select(t => t.Descricao).ToList();

                var text = new StringBuilder();
                text.AppendLine("Esses produtos estão indisponíveis no momento: ");
                foreach (var desc in produtosIndisponiveis)
                {
                    text.Append(desc + "; ");
                }

                throw new ExternalException(text.ToString());
            }
        }

        private void TrataEstoque(Carrinho carrinho)
        {
            var estoque = new EstoqueService();
            //Com essa variável consigo até especificar qual produto do carrinho não foi entregue.
            int produtosNaoEntregues = 0;
            foreach (var produto in carrinho.Produtos)
            {
                if (estoque.SolicitarProduto(produto))
                    estoque.BaixarEstoque(produto);
                else
                    produtosNaoEntregues++;
            }

            carrinho.FoiEntregue |= produtosNaoEntregues == 0;

            if (carrinho.FoiEntregue)
            {
                throw new ExternalException("Os produtos não foram entregues.");
            }
        }

        private void NotificadorSMS(Carrinho carrinho, bool notificarClienteSms)
        {
            if (notificarClienteSms)
            {
                if (!string.IsNullOrWhiteSpace(carrinho.Cliente.Celular))
                {
                    var smsService = new SmsService
                    {
                        Mensagem = "Obrigado por sua compra",
                        Celular = carrinho.Cliente.Celular
                    };
                    smsService.EnviarSms();
                }
            }
        }

        private void NotificadorEmail(Carrinho carrinho, bool notificarClienteEmail)
        {
            if (notificarClienteEmail)
            {
                if (!string.IsNullOrWhiteSpace(carrinho.Cliente.Email))
                {
                    using (var msg = new MailMessage("tiago.dantas@bancodaycoval.com.br", carrinho.Cliente.Email))
                    using (var smtp = new SmtpClient("servidor.smtp"))
                    {
                        msg.Subject = "Dados da sua compra";
                        msg.Body = $"Obrigado por efetuar sua compra conosco.";

                        smtp.Send(msg);
                    }
                }
            }
        }

        private bool EfetuaPagamento(Carrinho carrinho, DetalhePagamento detalhePagamento)
        {
            if (detalhePagamento.FormaPagamento.Equals(FormaPagamento.Dinheiro))
            {
                carrinho.FoiPago = true;
                return true;
            }

            using (var gatewayPatamento = new GatewayPagamentoService())
            {
                gatewayPatamento.Login = "login";
                gatewayPatamento.Senha = "senha";
                gatewayPatamento.FormaPagamentoCartao = (FormaPagamentoCartao)detalhePagamento.FormaPagamento;
                gatewayPatamento.NomeImpresso = detalhePagamento.NomeImpressoCartao;
                gatewayPatamento.AnoExpiracao = detalhePagamento.AnoExpiracao;
                gatewayPatamento.MesExpiracao = detalhePagamento.MesExpiracao;
                gatewayPatamento.Valor = carrinho.ValorTotalPedido;

                gatewayPatamento.EfetuarPagamento();

                carrinho.FoiPago = true;
                return true;
            }
        }

        private void CalculaImposto(Carrinho carrinho)
        {
            foreach (var produto in carrinho.Produtos)
            {
                switch (produto.TipoProduto)
                {
                    case TipoProduto.Alimentos:
                        produto.ValorImposto = produto.Valor * 0.05M;
                        carrinho.ValorTotalPedido += (produto.Valor + produto.ValorImposto) * produto.Quantidade;
                        break;
                    case TipoProduto.Eletronico:
                        produto.ValorImposto = produto.Valor * 0.15M;
                        carrinho.ValorTotalPedido += (produto.Valor + produto.ValorImposto) * produto.Quantidade;
                        break;
                    case TipoProduto.Superfulos:
                        produto.ValorImposto = produto.Valor * 0.20M;
                        carrinho.ValorTotalPedido += (produto.Valor + produto.ValorImposto) * produto.Quantidade;
                        break;
                    default:
                        throw new ArgumentException("O tipo de produto informado não está disponível.");
                }
            }
        }

        private bool VerificaDisponibilidade(Carrinho carrinho) {
            var estoque = new EstoqueService();
            int carrinhoDisponivel = 0;
            foreach (var produto in carrinho.Produtos)
            {
                if (!estoque.VerificaDisponibilidade(produto)) {
                    ProdutosIndisponiveis.Add(produto);
                    carrinhoDisponivel++;
                }
            }

            return carrinhoDisponivel == 0;
        }
    }
}