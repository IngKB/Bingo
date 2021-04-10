using Bingo.Domain.Base;
using Bingo.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Bingo.Domain
{
    public class Carton: Entity<int>
    {
        private Casilla[] Casillas;
        private Jugador Jugador { get; set; }
        public Carton()
        {
            CrearCarton();
        }

        public string MarcarNumero(int numero)
        {
            int posicion = EstaElNumeroEnCarton(numero);
            if(posicion != -1)
            {
                MarcarCasilla(posicion);

                if (VerificarCartonCompleto())
                {
                    return "Carton ganador: Carton lleno";
                }
                if (VerificarCartonFigura(FigurasCarton.FiguraX))
                {
                    return "Carton ganador: Figura X";
                }
                if (VerificarCartonFigura(FigurasCarton.FiguraL))
                {
                    return "Carton ganador: Figura L";
                }

            }
            return null;
        }

        public void AsignarJugador(Jugador jugador)
        {
            Jugador = jugador;
        }

        public bool VerificarCartonCompleto()
        {
            for(int i =0; i < 25; i++)
            {
                if (Casillas[i].Marcado == false)
                {
                    return false;
                }

            }
            return true;
        }

        public bool VerificarCartonFigura(Coordenada[] figura)
        {
            foreach (Coordenada cord in figura)
            {
              
                if (ObtenerCasillaEnCoordenada(cord).Marcado == false) return false;
            }
            return true;
        }


        private Casilla ObtenerCasillaEnCoordenada(Coordenada cord)
        {
            for (int i = 0; i < 25; i++)
            {
                
                if (Casillas[i].coordenada.SonCoordenadasIguales(cord))
                {
                    return Casillas[i];
                }
            }

            return null;
        }
        public int ObtenerNumeroEnCoordenada(Coordenada cord)
        {
            Casilla cas = ObtenerCasillaEnCoordenada(cord);
            if (cas != null)
            {
                return cas.Numero;
            }

            return -1;
        }

        public void CrearCarton()
        {
            Casillas = new Casilla[25];
            for(int i = 0; i < 25; i++)
            {
                Casillas[i] = new Casilla();
            }
            var rand = new Random();
            var minVal = 1;
            var maxVal = 16;
            var cont = 0;
            for (int i = 0; i<5;i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    if (!(i == 2 && j == 2))
                    {
                        var num = rand.Next(minVal, maxVal);

                        while (EstaElNumeroEnCarton(num)!=-1)
                        {
                            num = rand.Next(minVal, maxVal);
                        }

                        Casillas[cont].Numero = num;
                    }
                    else {
                        Casillas[cont].Marcado = true;
                        Casillas[cont].Numero = 0;
                    }

                    Casillas[cont].coordenada = new Coordenada(i, j);
                    cont++;
                }
                
                minVal += 15;
                maxVal += 15;
            }  
        }

        private int EstaElNumeroEnCarton(int num)
        {
            
            for (int i = 0; i < 25; i++)
            {
                if(Casillas[i].Numero == num)
                {
                    return i;
                }
            }
            return -1;
        }

        private bool MarcarCasilla(int posicion)
        {
            if (Casillas[posicion].Marcado == false)
            {
                Casillas[posicion].Marcado = true;
                return true;
            }

            return false;
        }
    }
}
