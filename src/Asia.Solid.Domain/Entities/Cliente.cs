using Asia.Solid.Domain.Services.Interfaces;

namespace Asia.Solid.Domain.Entities
{
    public class Cliente
    {
        private readonly IEmailService _emailService;
        private readonly ISmsService _smsService;

        public Cliente(IEmailService emailService, ISmsService smsService)
        {
            _emailService = emailService;
            _smsService = smsService;
        }
        
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }

        public bool EmailIsValid()
        {
            return _emailService.IsValid(Email);
        }
        public bool CelularIsValid()
        {
            return _smsService.CelularIsValid(Celular);
        }
    }
}