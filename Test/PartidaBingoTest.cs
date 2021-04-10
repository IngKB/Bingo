using Bingo.Domain;
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
            var partidaBingo = new PartidaBingo();

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
                cartones.Add(new Carton());
            }
            var partidaBingo = new PartidaBingo();
            partidaBingo.AgregarCartones(cartones);

            var respuesta = partidaBingo.SortearNumero(3);

            Assert.AreEqual("Numero registrado", respuesta);
        }



    }
}