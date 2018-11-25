using Asia.Solid.Domain.Entities;

namespace Asia.Solid.Domain.Services.Interfaces
{
    public interface IPagamentoService
    {
        Carrinho EfetuarPagamento(Carrinho carrinho, DetalhePagamento detalhePagamento);
    }
}
