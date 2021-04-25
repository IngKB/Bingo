using Bingo.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bingo.Domain.Entities
{
    public class Jugador : Entity<string>, IAggregateRoot
    {
        public string Identificacion { get; private set; }
        public string Primer_Nombre { get; private set; }
        public string Segundo_Nombre { get; private set; }
        public string Primer_Apellido { get; private set; }
        public string Segundo_Apellido { get; private set; }
        public string Telefono { get; private set; }
        public string Correo { get; private set; }
        public string Genero { get; private set; }
        public string Ciudad { get; private set; }

        public Jugador(string identificacion, string primer_Nombre, string segundo_Nombre, string primer_Apellido, string segundo_Apellido, string telefono, string correo, string genero, string ciudad)
        {
            Identificacion = identificacion;
            Primer_Nombre = primer_Nombre;
            Segundo_Nombre = segundo_Nombre;
            Primer_Apellido = primer_Apellido;
            Segundo_Apellido = segundo_Apellido;
            Telefono = telefono;
            Correo = correo;
            Genero = genero;
            Ciudad = ciudad;
        }
    } 
}
