namespace Asia.Solid.Domain.Services.Interfaces
{
    public interface IEmailService
    {
        bool IsValid(string email);
        void Enviar(string de, string para, string assunto, string mensagem);
    }
}
