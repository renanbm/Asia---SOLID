using Asia.Solid.Domain.Services.Interfaces;
using System.Net.Mail;

namespace Asia.Solid.Domain.Services
{
    public class EmailService: IEmailService
    {
        public bool IsValid(string email)
        {
            return !string.IsNullOrWhiteSpace(email);
        }

        public void Enviar(string de, string para, string assunto, string mensagem)
        {
            var mail = new MailMessage(de, para);
            var smtp = new SmtpClient("servidor.smtp");
            mail.Subject = assunto;
            mail.Body = mensagem;
            smtp.Send(mail);
        }
    }
}
