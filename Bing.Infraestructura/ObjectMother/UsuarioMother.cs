using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bingo.Domain.Entities;

namespace Bingo.Infraestructura.ObjectMother
{
    public static class UsuarioMother
    {
        public static Usuario CrearUsuario(string username)
        {
            return new Usuario(username, "1234567","1010101");
        }
    }
}
