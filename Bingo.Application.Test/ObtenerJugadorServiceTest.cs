using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bingo.Application.Test.Dobles;
using Bingo.Domain.Entities;
using Bingo.Infraestructura;
using Bingo.Infraestructura.ObjectMother;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Bingo.Application.Test
{
    public class ObtenerJugadorServiceTest
    {
        private BingoContext _context;
        private ObtenerJugadorService _service;
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
        public void ObtenerJugadorConIdTest()
        {
            //Arrange
            Jugador jugador = JugadorMother.CrearJugador("1001001001");
            _context.Jugadores.Add(jugador);
            _context.SaveChanges();

            _service = new ObtenerJugadorService(new UnitOfWork(_context), new EmailSenderDoble(), new JugadorRepository(_context));

            //Act
            var response = _service.GetxId(jugador.Identificacion);

            //Assert
            Assert.AreEqual(jugador, response.jugador);
        }

        [Test]
        public void ObtenerJugadorConCorreoTest()
        {
            Jugador jugador = JugadorMother.CrearJugador("1001001001");
            _context.Jugadores.Add(jugador);
            _context.SaveChanges();

            _service = new ObtenerJugadorService(new UnitOfWork(_context), new EmailSenderDoble(), new JugadorRepository(_context));
            
             var response = _service.GetxEmail(jugador.Correo);

            Assert.AreEqual(jugador, response.jugador);
        }
    }
}
