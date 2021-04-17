using Bingo.Application;
using Bingo.Infraestructura;
using Bingo.Infraestructura.System;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ConsoleUI
{
    class Program
    {

        static void Main(string[] args)
        {

            var email = new SendgridSender();

            var optionsMySql = new DbContextOptionsBuilder<BingoContext>()
                .UseMySQL("server=localhost;database=pruebabingo;user=root;").Options;
            //var optionsInMemory = new DbContextOptionsBuilder<BingoContext>()
            //.UseInMemoryDatabase("Bingo")
            //.Options;

            using var db = new BingoContext(optionsMySql);
            //using var db = new BingoContext();
            CrearCarton(db, email);

        }
        private static void CrearCarton(BingoContext context, SendgridSender emailsender)
        {
            CrearCartonService _service = new CrearCartonService(new UnitOfWork(context), emailsender, new CartonRepository(context));
            var requestCrear = new CrearCartonRequest() { JugadorID = "100110" };

            CrearCartonResponse responseCrear = _service.Ejecutar(requestCrear);

            Console.WriteLine(responseCrear.Mensaje);
        }
    }
}
