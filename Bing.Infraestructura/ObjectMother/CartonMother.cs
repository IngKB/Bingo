using Bingo.Domain.Entities;
using Bingo.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo.Infraestructura.ObjectMother
{
    public static class CartonMother
    {
        public static Carton CrearCarton(int eventoid, string jugadorid)
        {
            Carton carton = new Carton(eventoid, jugadorid);
            carton.Casillas = new List<Casilla>();
            for (int i = 0; i < 25; i++)
            {
                carton.Casillas.Add(new Casilla());
            }
            var rand = new Random();
            var minVal = 1;
            var maxVal = 16;
            var cont = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!(i == 2 && j == 2))
                    {
                        var num = rand.Next(minVal, maxVal);

                        while (EstaElNumeroEnCarton(num, carton.Casillas) != -1)
                        {
                            num = rand.Next(minVal, maxVal);
                        }

                        carton.Casillas[cont].Numero = num;
                    }
                    else
                    {
                        carton.Casillas[cont].Marcado = true;
                        carton.Casillas[cont].Numero = 0;
                    }

                    carton.Casillas[cont].coordenada = new Coordenada(i, j);
                    cont++;
                }

                minVal += 15;
                maxVal += 15;
            }
            return carton;
        }

        private static int EstaElNumeroEnCarton(int num, List<Casilla> Casillas)
        {

            for (int i = 0; i < 25; i++)
            {
                if (Casillas[i].Numero == num)
                {
                    return i;
                }
            }
            return -1;
        }

    }
}
