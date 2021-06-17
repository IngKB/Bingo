using Bingo.Domain.Base;
using Bingo.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Bingo.Domain.Entities
{
    public class Carton : Entity<int>, IAggregateRoot
    {
        public int EventoId { get;private set;}
        public List<Casilla> Casillas { get; set; }
        public string JugadorId { get; private set; }
        public Carton(int eventoId, string jugadorId)
        {
            EventoId = eventoId;
            JugadorId = jugadorId;
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

        public void AsignarJugador(string jugador)
        {
            JugadorId = jugador;
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
