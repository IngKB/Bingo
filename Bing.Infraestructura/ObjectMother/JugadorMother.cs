using Bingo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo.Infraestructura.ObjectMother
{
    public static class JugadorMother
    {
        public static Jugador CrearJugador(string identificacion)
        {
            return new Jugador(identificacion, "Carlos", "Andres", "Baquero", "Cañas", "3001231231", "correo@mail.com", "masculino", "Valledupar");
        }
    }
}
