using Asia.Solid.Domain.Entities;
using Asia.Solid.Domain.Services.Interfaces;

namespace Asia.Solid.Domain.Services
{
    public class PagamentoNaoRealizadoService : IPagamentoService
    {
        private readonly ICarrinhoService _carrinhoService;

        public PagamentoNaoRealizadoService(ICarrinhoService carrinhoService)
        {
            _carrinhoService = carrinhoService;
        }

        public Carrinho EfetuarPagamento(Carrinho carrinho, DetalhePagamento detalhePagamento)
        {
            carrinho = _carrinhoService.InformarNaoPagamento(carrinho);

            return carrinho;
        }
    }
}

