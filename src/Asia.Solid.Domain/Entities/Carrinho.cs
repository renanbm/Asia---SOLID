using System.Collections.Generic;

namespace Asia.Solid.Domain.Entities
{
    public class Carrinho
    {
        public decimal ValorTotalPedido { get; set; }
        public List<Produto> Produtos { get; set; }
        public Cliente Cliente { get; set; }
        public bool FoiPago { get; set; }
        public bool FoiEntregue { get; set; }

        public void CalcularValorTotalPedido()
        {
            ValorTotalPedido = 0M;

            foreach (var produto in Produtos)
            {
                produto.CalcularValorTotal();
                ValorTotalPedido += produto.ValorCalculado;
            }
        }

        public void InformarPagamento()
        {
            FoiPago = true;
        }

        public void InformarNaoPagamento()
        {
            FoiPago = false;
        }

        public void EntregarProdutos()
        {
            FoiEntregue = true;
        }
    }
}