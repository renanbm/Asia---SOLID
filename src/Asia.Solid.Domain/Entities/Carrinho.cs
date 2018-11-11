using System.Collections.Generic;

namespace Asia.Solid.Domain.Entities
{
    public class Carrinho
    {
        public decimal ValorTotalPedido { get; set; }
        public IList<Produto> Produtos { get; set; }
        public Cliente Cliente { get; set; }
        public bool FoiPago { get; set; }
        public bool FoiEntregue { get; set; }
    }
}