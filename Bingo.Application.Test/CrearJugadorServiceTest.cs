using Bingo.Application.Test.Dobles;
using Bingo.Application.Test.Fake;
using Bingo.Domain.Entities;
using Bingo.Infraestructura;
using Bingo.Infraestructura.ObjectMother;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo.Application.Test
{
    public class CrearJugadorServiceTest
    {
        private BingoContext _context;
        private CrearJugadorService _service;
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
        public void CrearJugadorTest()
        {
            _service = new CrearJugadorService(new UnitOfWork(_context), new EmailSenderDoble(), new JugadorRepository(_context));

            Jugador jugador = JugadorMother.CrearJugador("1001001001");

            var response = _service.Ejecutar(new CrearJugadorRequest(jugador));

            Assert.AreEqual($"Bienvenido {jugador.Primer_Nombre}", response.mensaje);
        }
    }
}
