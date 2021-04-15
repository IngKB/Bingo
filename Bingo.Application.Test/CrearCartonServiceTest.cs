using Bingo.Application.Test.Fake;
using Bingo.Infraestructura;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace Bingo.Application.Test
{
    public class CrearCartonServiceTest
    {

        BingoContext _context;
        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<BingoContext>().UseInMemoryDatabase("Bingo").Options;
            _context = new BingoContext(optionsInMemory);
        }

        [Test]
        public void CrearCartonTest()
        {
            var request = new CrearCartonRequest { JugadorID = "101" };
            CrearCartonService _service = new CrearCartonService(new UnitOfWork(_context), new EmailSenderFake());

            var response = _service.Ejecutar(request);
            Assert.AreEqual("Carton registrado",response.Mensaje);
        }
    }
}