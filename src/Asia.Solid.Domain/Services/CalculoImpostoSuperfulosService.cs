using Asia.Solid.Domain.Entities;
using Asia.Solid.Domain.Services.Interfaces;

namespace Asia.Solid.Domain.Services
{
    public class CalculoImpostoSuperfulosService: ICalculoImpostoService
    {
        public Produto AplicarImposto(Produto produto)
        {
            produto.ValorImposto = produto.Valor * Constantes.IMPOSTO_TIPO_PRODUTO_SUPERFULOS;
            return produto;
        }
    }
}

