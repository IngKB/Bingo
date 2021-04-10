using Bingo.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bingo.Domain.Entities
{
    public class Jugador : Entity<int>
    {
        private string Primer_Nombre { get; set; }
        private string Segundo_Nombre { get; set; }
        private string Primer_Apellido { get; set; }
        private string Segundo_Apellido { get; set; }
        private string Telefono { get; set; }
        private string Correo { get; set; }
        private string Genero { get; set; }
    }
}
