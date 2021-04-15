using Bingo.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo.Application.Test.Fake
{

     public class EmailSenderFake : IEmailSender
     {
         public Task SendEmailAsync(string email, string subject, string htmlMessage)
         {
             Console.WriteLine($"Se ha enviado el correo Fake satisfactoriamente. a {email}");
             return Task.CompletedTask;
         }
     }
}
