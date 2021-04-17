using System;
using System.Collections.Generic;
using System.Text;

namespace Bingo.Domain.ValueObjects
{
    public class Casilla
    {
        public int Numero { get; set; }
        public bool Marcado { get; set; }
        public Coordenada coordenada { get; set; }
        
    }
}
