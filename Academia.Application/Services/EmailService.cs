using MimeKit;
using MailKit.Net.Smtp;

namespace Academia.Application.Services
{
    public class EmailService
    {
        public static void SendConfirmationEmail(string toEmail, string clientName)
        {
            // Configure as credenciais do servidor SMTP
            var smtpServer = "smtp.gmail.com"; // Substitua pelo seu servidor SMTP
            var smtpPort = 587; // Substitua pela porta do seu servidor SMTP
            var smtpUsername = "f.santosdev1992@gmail.com"; // Substitua pelo seu email
            var smtpPassword = "ruzm otfz iwde ddej"; // Substitua pela sua senha

            // Crie um novo email
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(smtpUsername));
            message.To.Add(MailboxAddress.Parse(toEmail));
            message.Subject = "Confirmação de Cadastro";

            // Crie o corpo do email
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = $"<p>Olá {clientName},</p>" +
                                   "<p>Obrigado por se cadastrar!</p>" +
                                   "<p>Seu cadastro foi realizado com sucesso.</p>";
            message.Body = bodyBuilder.ToMessageBody();

            // Envie o email
            var client = new SmtpClient();
            client.Connect(smtpServer, smtpPort, false);
            client.Authenticate(smtpUsername, smtpPassword);
            client.Send(message);
            client.Disconnect(true);
        }
    }
}
