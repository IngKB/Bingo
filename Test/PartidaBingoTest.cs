using Bingo.Domain;
using Bingo.Domain.Entities;
using NUnit.Framework;
using System.Collections.Generic;

namespace Bingo.Domain.Test
{
    public class PartidaBingoTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(76, "El numero sobrepasa el limite", TestName = "SortearNumeroSuperiorAlLimite")]
        [TestCase(0, "El numero esta por debajo del limite inferior", TestName = "SortearNumeroInferiorAlLimite")]
        public void SortearNumeroTest(int numero, string resultadoEsperado)
        {
            //Arrange
            var partidaBingo = new PartidaBingo("X");

            //Act
            string resultado = partidaBingo.SortearNumero(numero);
           
            //Assert
            Assert.AreEqual(resultado, resultadoEsperado);
        }

        /*
         Caso exitoso de sortear un numero
         */
        [Test]
        public void SortearNumeroEnCartones()
        {

            //Toca inicializaro los cartones
            List<Carton> cartones = new List<Carton>();

            for (int i = 0; i < 20; i++)
            {
                cartones.Add(new Carton(1,"001"));
            }
            var partidaBingo = new PartidaBingo("X");
            partidaBingo.AgregarCartones(cartones);

            var respuesta = partidaBingo.SortearNumero(3);

            Assert.AreEqual("Numero registrado", respuesta);
        }



    }
}