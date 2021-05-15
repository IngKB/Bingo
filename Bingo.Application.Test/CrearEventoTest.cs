using Bingo.Application.Test.Dobles;
using Bingo.Domain;
using Bingo.Domain.Entities;
using Bingo.Infraestructura;
using Bingo.Infraestructura.ObjectMother;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo.Application.Test
{
    public class CrearEventoTest
    {
        private BingoContext _context;
        private CrearEventoBingoService _service;
        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<BingoContext>()
                .UseSqlite(SqlLiteDatabaseInMemory.CreateConnection())
                .Options;
            _context = new BingoContext(optionsInMemory);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [Test]
        public void CrearEventoBingoTest()
        {
            _service = new CrearEventoBingoService(new UnitOfWork(_context), new EventoBingoRepository(_context));

            List<PartidaBingo> partidas = new();
            partidas.Add(new PartidaBingo("L"));
            partidas.Add(new PartidaBingo("O"));

            var response = _service.Ejecutar(new CrearEventoBingoRequest(partidas, DateTime.Now));

            Assert.AreEqual($"Evento creaduo", response.mensaje);
        }
    }
}
