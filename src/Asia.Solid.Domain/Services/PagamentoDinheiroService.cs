using Asia.Solid.Domain.Entities;
using Asia.Solid.Domain.Services.Interfaces;

namespace Asia.Solid.Domain.Services
{
    public class PagamentoDinheiroService : IPagamentoService
    {
        private readonly ICarrinhoService _carrinhoService;

        public PagamentoDinheiroService(ICarrinhoService carrinhoService)
        {
            _carrinhoService = carrinhoService;
        }

        public Carrinho EfetuarPagamento(Carrinho carrinho, DetalhePagamento detalhePagamento)
        {
            carrinho = _carrinhoService.InformarPagamento(carrinho);

            return carrinho;
        }
    }
}

