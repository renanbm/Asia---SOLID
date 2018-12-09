using Asia.Solid.Domain.Entities;

namespace Asia.Solid.Domain.Services.Interfaces
{
    public interface IPedidoService
    {
        void EfetuarPedido(Carrinho carrinho, Pagamento pagamento, bool notificarClienteEmail, bool notificarClienteSms);
    }
}
