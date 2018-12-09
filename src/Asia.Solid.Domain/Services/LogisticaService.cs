using Asia.Solid.Domain.Entities;
using Asia.Solid.Domain.Services.Interfaces;
using System.Runtime.InteropServices;

namespace Asia.Solid.Domain.Services
{
    public class LogisticaService : ILogisticaService
    {
        private readonly IEstoqueService _estoqueService;

        public LogisticaService(IEstoqueService estoqueService)
        {
            _estoqueService = estoqueService;
        }

        public void SolicitarProdutos(Carrinho carrinho)
        {
            foreach (var produto in carrinho.Produtos)
            {
                //Este método não precisa ser implementado.
            }

            carrinho.EntregarProdutos();

            if (carrinho.FoiEntregue)
                _estoqueService.BaixarEstoque(carrinho.Produtos);
            else
                throw new ExternalException("Os produtos não foram entregues.");
        }
    }
}