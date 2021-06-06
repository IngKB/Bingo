using Bingo.Application.CartonServices;
using Bingo.Application.Test.Dobles;
using Bingo.Domain.Entities;
using Bingo.Infraestructura;
using Bingo.Infraestructura.ObjectMother;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bingo.Application.Test
{
    public class ObtenerCartonTest
    {
        private BingoContext _context;
        private ObtenerCartonService _service;

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
        public void ObtenerCartonServiceTest()
        {
            List<PartidaBingo> partidas = new();
            partidas.Add(new PartidaBingo("L"));
            partidas.Add(new PartidaBingo("O"));
            EventoBingo evento = new EventoBingo(partidas, DateTime.Now);
            Jugador jugador = JugadorMother.CrearJugador("100001");
            _context.Jugadores.Add(jugador);
            _context.Eventos.Add(evento);

            Carton carton = new Carton(evento.Id, jugador.Identificacion);
            _context.Cartones.Add(carton);
            _context.SaveChanges();
            _service = new ObtenerCartonService(new UnitOfWork(_context), new CartonRepository(_context), new JugadorRepository(_context));

            var response = _service.Ejecutar(jugador.Identificacion);
            Console.WriteLine(response.Cartones.ToString());
            Assert.AreEqual(0, response.estado);
        }
    }
}
