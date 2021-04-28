using Bingo.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bingo.Domain.Entities
{
    public class Usuario : Entity<int>, IAggregateRoot
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }

        public string JugadorId { get; private set;}

        public Usuario(string userName, string password, string jugadorId)
        {
            UserName = userName;
            Password = password;
            JugadorId = jugadorId;
        }
    }
}
