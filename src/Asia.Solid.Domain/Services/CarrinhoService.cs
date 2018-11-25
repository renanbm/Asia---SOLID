using Asia.Solid.Domain.Entities;
using Asia.Solid.Domain.Factories.Interfaces;
using Asia.Solid.Domain.Services.Interfaces;
using System.Collections.Generic;

namespace Asia.Solid.Domain.Services
{
    public class CarrinhoService: ICarrinhoService
    {
        private readonly ICalculoImpostoTipoProdutoFactory _impostoTipoProduto;

        public CarrinhoService(ICalculoImpostoTipoProdutoFactory impostoTipoProduto)
        {
            _impostoTipoProduto = impostoTipoProduto;
        }

        public decimal CalcularValorTotalPedido(List<Produto> produtos)
        {
            decimal valorTotalPedido = 0M;

            foreach (var produto in produtos)
            {
                var produtoComImposto = _impostoTipoProduto.GetCalculoImpostoTipoProduto(produto.TipoProduto).AplicarImposto(produto);
                valorTotalPedido += (produtoComImposto.Valor + produtoComImposto.ValorImposto) * produtoComImposto.Quantidade;
            }
            return valorTotalPedido;
        }

        public Carrinho InformarPagamento(Carrinho carrinho)
        {
            carrinho.FoiPago = true;
            return carrinho;
        }

        public Carrinho InformarNaoPagamento(Carrinho carrinho)
        {
            carrinho.FoiPago = false;
            return carrinho;
        }

        public Carrinho EntregarProdutos(Carrinho carrinho)
        {
            carrinho.FoiEntregue = true;
            return carrinho;
        }
    }
}

