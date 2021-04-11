using Bingo.Application;
using Bingo.Infraestructura;
using Microsoft.EntityFrameworkCore;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using(var db = new BingoContext())
            {

             var optionsInMemory = new DbContextOptionsBuilder<BingoContext>()
             .UseInMemoryDatabase("Bingo")
             .Options;

                CrearCarton(db);
            }
            
        }
        private static void CrearCarton(BingoContext context)
        {
            CrearCartonService _service = new CrearCartonService(new UnitOfWork(context));
            var requestCrear = new CrearCartonRequest() {JugadorID="100010"};

            CrearCartonResponse responseCrear = _service.Ejecutar(requestCrear);

            Console.WriteLine(responseCrear.Mensaje);
        }
    }
}
