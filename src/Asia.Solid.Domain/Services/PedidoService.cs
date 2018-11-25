using Asia.Solid.Domain.Entities;
using Asia.Solid.Domain.Factories.Interfaces;
using Asia.Solid.Domain.Services.Interfaces;
using System.Runtime.InteropServices;

namespace Asia.Solid.Domain.Services
{
    public class PedidoService: IPedidoService
    {
        private readonly ICarrinhoService _carrinhoService;
        private readonly IPagamentoFormaPagamentoFactory _pagamentoFormaPagamentoFactory;
        private readonly IEstoqueService _estoqueService;
        private readonly IEmailService _emailService;
        private readonly ISmsService _smsService;

        public PedidoService(ICarrinhoService carrinhoService, IPagamentoFormaPagamentoFactory pagamentoFormaPagamentoFactory, IEstoqueService estoqueService, IEmailService emailService, ISmsService smsService)
        {
            _carrinhoService = carrinhoService;
            _pagamentoFormaPagamentoFactory = pagamentoFormaPagamentoFactory;
            _estoqueService = estoqueService;
            _emailService = emailService;
            _smsService = smsService;
        }

        public void EfetuarPedido(Carrinho carrinho, DetalhePagamento detalhePagamento, bool notificarClienteEmail, bool notificarClienteSms)
        {
            carrinho.ValorTotalPedido = _carrinhoService.CalcularValorTotalPedido(carrinho.Produtos);

            carrinho = _pagamentoFormaPagamentoFactory.GetPagamentoFormaPagamento(detalhePagamento.FormaPagamento).EfetuarPagamento(carrinho, detalhePagamento);

            if (carrinho.FoiPago)
                carrinho = _estoqueService.SolicitarProdutos(carrinho);
            else
                throw new ExternalException("O pagamento não foi efetuado.");

            if (notificarClienteEmail && carrinho.Cliente.EmailIsValid())
                _emailService.Enviar("tiago.dantas@bancodaycoval.com.br", carrinho.Cliente.Email, "Dados da sua compra", $"Obrigado por efetuar sua compra conosco.");

            if (notificarClienteSms && carrinho.Cliente.CelularIsValid())
                _smsService.Enviar(carrinho.Cliente.Celular, "Obrigado por sua compra");
        }
    }
}