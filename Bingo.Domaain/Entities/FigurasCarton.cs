using Bingo.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bingo.Domain
{
    public static class FigurasCarton
    {
       
        public static Coordenada[] Figuras(string forma)
        {
            switch (forma)
            {
                case "X": return FiguraX;
                case "L": return FiguraL;
                default:
                    return null;
            }
        }

        public static Coordenada[] FiguraX =
          new Coordenada[]{
                new Coordenada(0,0),
                new Coordenada(1,1),
                new Coordenada(3,3),
                new Coordenada(4,4),
                new Coordenada(0,4),
                new Coordenada(1,3),
                new Coordenada(3,1),
                new Coordenada(4,0),
          };

        public static Coordenada[] FiguraL =
         new Coordenada[]{
                new Coordenada(0,0),
                new Coordenada(0,1),
                new Coordenada(0,2),
                new Coordenada(0,3),
                new Coordenada(0,4),
                new Coordenada(1,4),
                new Coordenada(2,4),
                new Coordenada(3,4),
                new Coordenada(4,4),
         };

    }
}
