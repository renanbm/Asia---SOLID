using Asia.Solid.Domain.Entities;
using Asia.Solid.Domain.Factories.Interfaces;
using Asia.Solid.Domain.Services;
using Asia.Solid.Domain.Services.Interfaces;

namespace Asia.Solid.Domain.Factories
{
    public class PagamentoFormaPagamentoFactory : IPagamentoFormaPagamentoFactory
    {
        private readonly ICarrinhoService _carrinhoService;
        private readonly IGatewayPagamentoService _gatewayPagamentoService;

        public PagamentoFormaPagamentoFactory(ICarrinhoService carrinhoService, IGatewayPagamentoService gatewayPagamentoService)
        {
            _carrinhoService = carrinhoService;
            _gatewayPagamentoService = gatewayPagamentoService;
        }

        public IPagamentoService GetPagamentoFormaPagamento(FormaPagamento formaPagamento)
        {
            IPagamentoService pagamentoFormaPagamento;

            switch (formaPagamento)
            {
                case FormaPagamento.CartaoDebito:
                    pagamentoFormaPagamento = new PagamentoCartaoDebitoService(_carrinhoService, _gatewayPagamentoService);
                    break;
                case FormaPagamento.CartaoCredito:
                    pagamentoFormaPagamento = new PagamentoCartaoCreditoService(_carrinhoService, _gatewayPagamentoService);
                    break;
                case FormaPagamento.Dinheiro:
                    pagamentoFormaPagamento = new PagamentoDinheiroService(_carrinhoService);
                    break;
                default:
                    pagamentoFormaPagamento = new PagamentoNaoRealizadoService(_carrinhoService);
                    break;
            }
            return pagamentoFormaPagamento;
        }
    }
}
