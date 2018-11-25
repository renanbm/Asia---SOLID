using Asia.Solid.Domain.Entities;
using Asia.Solid.Domain.Services.Interfaces;

namespace Asia.Solid.Domain.Services
{
    public class PagamentoCartaoCreditoService : IPagamentoService
    {
        private readonly ICarrinhoService _carrinhoService;
        private readonly IGatewayPagamentoService _gatewayPagamentoService;

        public PagamentoCartaoCreditoService(ICarrinhoService carrinhoService, IGatewayPagamentoService gatewayPagamentoService)
        {
            _carrinhoService = carrinhoService;
            _gatewayPagamentoService = gatewayPagamentoService;
        }

        public Carrinho EfetuarPagamento(Carrinho carrinho, DetalhePagamento detalhePagamento)
        {
            _gatewayPagamentoService.EfetuarPagamento("login", "senha", detalhePagamento, carrinho.ValorTotalPedido);

            carrinho = _carrinhoService.InformarPagamento(carrinho);

            return carrinho;
        }
    }
}

