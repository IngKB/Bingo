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
    class LoginServiceTest
    {
        private BingoContext _context;
        private LoginUsuarioService _service;
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
        public void LoginUserTest()
        {

            _service = new LoginUsuarioService(new UnitOfWork(_context), new EmailSenderDoble(),
                new UsuarioRepository(_context), new JugadorRepository(_context));
            Jugador jugador = JugadorMother.CrearJugador("100001");
            Usuario usuario = new Usuario("user1", "123456", jugador.Identificacion);

            _context.Jugadores.Add(jugador);
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            var response = _service.Ejecutar(new LoginUsuarioRequest(usuario));

            Assert.AreEqual($"Bienvenido {usuario.UserName}", response.Mensaje);
        }
    }
}
