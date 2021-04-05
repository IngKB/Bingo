using Bingo.Domain;
using NUnit.Framework;

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
         DADO que exista una partida de bingo y sus respectivos cartones
         CUANDO se sortee un número
         ENTONCES el sistema debe marcar el número en los cartones
         */
        [Test]
        public void SortearNumeroEnCartones()
        {

            //Toca inicializaro los cartones
            var cartones = new Carton[25];
            var partidaBingo = new PartidaBingo();
            partidaBingo.AsignarCartones(cartones);

            partidaBingo.SortearNumero(3);
        }



    }
}