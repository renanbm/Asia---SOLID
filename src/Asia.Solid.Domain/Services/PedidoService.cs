using Asia.Solid.Domain.Entities;
using Asia.Solid.Domain.Services.Interfaces;
using System.Runtime.InteropServices;

namespace Asia.Solid.Domain.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly ILogisticaService _logisticaService;
        private readonly IEmailService _emailService;
        private readonly ISmsService _smsService;

        public PedidoService(ILogisticaService logisticaService, IEmailService emailService, ISmsService smsService)
        {
            _logisticaService = logisticaService;
            _emailService = emailService;
            _smsService = smsService;
        }

        public void EfetuarPedido(Carrinho carrinho, Pagamento pagamento, bool notificarClienteEmail, bool notificarClienteSms)
        {
            carrinho.CalcularValorTotalPedido();

            carrinho = pagamento.EfetuarPagamento();

            if (carrinho.FoiPago)
                _logisticaService.SolicitarProdutos(carrinho);
            else
                throw new ExternalException("O pagamento não foi efetuado.");

            if (notificarClienteEmail && carrinho.Cliente.EmailIsValid())
                _emailService.Enviar("tiago.dantas@bancodaycoval.com.br", carrinho.Cliente.Email, "Dados da sua compra", $"Obrigado por efetuar sua compra conosco.");

            if (notificarClienteSms && carrinho.Cliente.CelularIsValid())
                _smsService.Enviar(carrinho.Cliente.Celular, "Obrigado por sua compra");
        }
    }
}