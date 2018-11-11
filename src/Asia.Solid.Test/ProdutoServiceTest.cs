using Asia.Solid.Domain.Entities;
using Asia.Solid.Domain.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace Asia.Solid.Test
{
    [TestFixture()]
    public class ProdutoServiceTest
    {
        public PedidoService PedidoService { get; set; }

        public ProdutoServiceTest()
        {
            this.PedidoService = new PedidoService();
        }

        [Test()]
        public void EfetuarPedidoTest()
        {
            var produtos = new List<Produto>();
            var cliente = new Cliente();
            var carrinho = new Carrinho 
            {
                Cliente = cliente
            };

            PedidoService.EfetuarPedido(carrinho, null, true, true);

            Assert.IsTrue(true);
        }
    }
}