using Bingo.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Bingo.Infraestructura.System
{
    public class SendgridSender : IEmailSender
    {
        public SendgridSender()
        {
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return  Execute(subject, htmlMessage, email);
        }

        async Task Execute(string subject, string message, string email)
        {   
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("karlosmario0123@gmail.com");
            var to = new EmailAddress(email);
            var plainTextContent = "confirmacion";
            var htmlContent = $"<strong>{message}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            Console.WriteLine(response.StatusCode.ToString());
        }
    }
}
