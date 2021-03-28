using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Bingo.Domain.Test
{
    public class CartonTest
    {

        [Test]
        public void VerificarVictoriaConCartonLleno()
        {
            //Arrange
            Carton carton = new Carton();
            string respuesta ="";
            //Act
            for (int i = 0; i < 75; i++)
            {
                var res = carton.MarcarNumero(i + 1);
                if (res !=null)
                respuesta = res;
            }

            //Assert
            Assert.AreEqual("Carton ganador: Carton lleno", respuesta);

        }
        [TestCase("X",TestName = "VerificarVictoriaConFormaX",ExpectedResult = "Carton ganador: Figura X")]
        [TestCase("L", TestName = "VerificarVictoriaConFormaL", ExpectedResult = "Carton ganador: Figura L")]
        public string VerificarVictoriaConFigura(string figura)
        {
            //Arange
            Carton carton = new Carton();
            string respuesta = "";

            //Act
            foreach (var cord in FigurasCarton.Figuras(figura))
            {
                respuesta = carton.MarcarNumero(carton.ObtenerNumeroEnCoordenada(cord));
            }

            return respuesta;
        }
    }
}
