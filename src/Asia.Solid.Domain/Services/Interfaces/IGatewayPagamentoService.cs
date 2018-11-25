using Asia.Solid.Domain.Entities;

namespace Asia.Solid.Domain.Services.Interfaces
{
    public interface IGatewayPagamentoService
    {
        void EfetuarPagamento(string login, string senha, DetalhePagamento detalhePagamento, decimal valor);
    }
}
