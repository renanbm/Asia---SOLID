using Asia.Solid.Domain.Entities;
using Asia.Solid.Domain.Services.Interfaces;

namespace Asia.Solid.Domain.Factories.Interfaces
{
    public interface IPagamentoFormaPagamentoFactory
    {
        IPagamentoService GetPagamentoFormaPagamento(FormaPagamento formaPagamento);
    }
}
