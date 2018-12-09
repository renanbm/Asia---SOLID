namespace Asia.Solid.Domain.Services.Interfaces
{
    public interface ISmsService
    {
        bool CelularIsValid(string celular);
        void Enviar(string celular, string mensagem);
    }
}
