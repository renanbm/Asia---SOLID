using Asia.Solid.Domain.Entities;

namespace Asia.Solid.Domain.Services.Interfaces
{
    public interface IPedidoService
    {
        void EfetuarPedido(Carrinho carrinho, DetalhePagamento detalhePagamento, bool notificarClienteEmail, bool notificarClienteSms);
    }
}
