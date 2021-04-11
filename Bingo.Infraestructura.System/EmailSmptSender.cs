using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Bingo.Infraestructura.System
{
    public class EmailSmptSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            SmtpClient client = new SmtpClient("smtp-relay.sendinblue.com");
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("username", "password");

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("whoever@me.com");
            mailMessage.To.Add("receiver@me.com");
            mailMessage.Body = "body";
            mailMessage.Subject = "subject";
            client.Send(mailMessage);
            return Task.CompletedTask;
        }
    }
}
