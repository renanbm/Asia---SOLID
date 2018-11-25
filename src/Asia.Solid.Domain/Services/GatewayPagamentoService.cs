using Asia.Solid.Domain.Entities;
using Asia.Solid.Domain.Services.Interfaces;

namespace Asia.Solid.Domain.Services
{
    public class GatewayPagamentoService: IGatewayPagamentoService
    {
        public void EfetuarPagamento(string login, string senha, DetalhePagamento detalhePagamento, decimal valor)
        {
            var gatewayPagamento = new GatewayPagamento()
            {
                Login = login,
                Senha = senha,
                FormaPagamentoCartao = (FormaPagamentoCartao)detalhePagamento.FormaPagamento,
                NomeImpresso = detalhePagamento.NomeImpressoCartao,
                AnoExpiracao = detalhePagamento.AnoExpiracao,
                MesExpiracao = detalhePagamento.MesExpiracao,
                Valor = valor
            };
            //Não é necessário implementar este método.
        }
    }
}