using Asia.Solid.Domain.Entities;

namespace Asia.Solid.Domain.Services.Interfaces
{
    public interface ICalculoImpostoService
    {
        Produto AplicarImposto(Produto produto);
    }
}
