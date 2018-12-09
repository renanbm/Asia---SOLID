using Asia.Solid.Domain.Entities;
using System.Collections.Generic;

namespace Asia.Solid.Domain.Services.Interfaces
{
    public interface IEstoqueService
    {
        void BaixarEstoque(List<Produto> produtos);
    }
}
