using Asia.Solid.Domain.Entities;
using System.Collections.Generic;

namespace Asia.Solid.Domain.Services.Interfaces
{
    public interface ICarrinhoService
    {
        decimal CalcularValorTotalPedido(List<Produto> produtos);
        Carrinho InformarPagamento(Carrinho carrinho);
        Carrinho InformarNaoPagamento(Carrinho carrinho);
        Carrinho EntregarProdutos(Carrinho carrinho);
    }
}
