using Asia.Solid.Domain.Services.Interfaces;

namespace Asia.Solid.Domain.Services
{
    public class SmsService: ISmsService
    {
        public bool CelularIsValid(string celular)
        {
            return !string.IsNullOrWhiteSpace(celular);
        }

        public void Enviar(string celular, string mensagem)
        {
            //Este método não precisa ser implementado.
        }
    }
}