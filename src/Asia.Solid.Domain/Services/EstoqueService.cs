using Asia.Solid.Domain.Entities;
using Asia.Solid.Domain.Services.Interfaces;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Asia.Solid.Domain.Services
{
    public class EstoqueService: IEstoqueService
    {
        private readonly ICarrinhoService _carrinhoService;

        public EstoqueService(ICarrinhoService carrinhoService)
        {
            _carrinhoService = carrinhoService;
        }

        public Carrinho SolicitarProdutos(Carrinho carrinho)
        {
            foreach (var produto in carrinho.Produtos)
            {
                //Este método não precisa ser implementado.
            }

            carrinho = _carrinhoService.EntregarProdutos(carrinho);

            if (carrinho.FoiEntregue)
                BaixarEstoque(carrinho.Produtos);
            else
                throw new ExternalException("Os produtos não foram entregues.");

            return carrinho;
        }

        public void BaixarEstoque(List<Produto> produtos)
        {
            //Este método não precisa ser implementado.
        }
    }
}