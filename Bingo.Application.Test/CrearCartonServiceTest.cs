using Bingo.Application.Test.Fake;
using Bingo.Infraestructura;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace Bingo.Application.Test
{
    public class CrearCartonServiceTest
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CrearCartonTest()
        {
            CrearCartonService _service = new CrearCartonService();

            var response = _service.Ejecutar();
            Assert.AreEqual(0,response.estado);
        }
    }
}