using Asia.Solid.Domain.Entities;
using System.Collections.Generic;

namespace Asia.Solid.Domain.Services.Interfaces
{
    public interface IEstoqueService
    {
        Carrinho SolicitarProdutos(Carrinho carrinho);
        void BaixarEstoque(List<Produto> produtos);
    }
}
