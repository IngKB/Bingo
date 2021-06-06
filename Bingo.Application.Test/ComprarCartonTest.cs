using Bingo.Application.Test.Dobles;
using Bingo.Domain.Entities;
using Bingo.Infraestructura;
using Bingo.Infraestructura.ObjectMother;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace Bingo.Application.Test
{
    public class ComprarCartonTest
    {
        private BingoContext _context;
        private ComprarCartonService _service;

        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<BingoContext>()
               .UseSqlite(SqlLiteDatabaseInMemory.CreateConnection())
               .Options;
            _context = new BingoContext(optionsInMemory);
            _context.Database.EnsureCreated();
        }

        [Test]
        public void ComprarCartonServiceTest()
        {
            EventoBingo evento = new EventoBingo();
            Jugador jugador = JugadorMother.CrearJugador("100001");
            _context.Eventos.Add(evento);
            _context.Jugadores.Add(jugador);
            _context.SaveChanges();
            _service = new ComprarCartonService(new UnitOfWork(_context),new CartonRepository(_context),new JugadorRepository(_context), new EventoBingoRepository(_context));

            Carton carton = new Carton(evento.Id, jugador.Identificacion);
            carton.CrearCarton();
            var response = _service.Ejecutar(new ComprarCartonRequest(carton));

            Assert.AreEqual(0, response.estado);
        }
    }
}
