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
            string[] respuestas = new string[75];
            bool isGanador = false;
            //Act
            for (int i = 0; i < 75; i++)
            {
                respuestas.SetValue(carton.MarcarNumero(i+1),i);
            }

            for (int i = 0; i < 75; i++)
            {           
                if (respuestas[i]!=null ) {
                    if (respuestas[i].Contains("Carton ganador"))
                    isGanador = true;
                };
            }

            //Assert
            Assert.IsTrue(isGanador);

        }
    }
}
