using Bingo.Domain.Entities;
using Bingo.Domain.Repositories;
using Bingo.Infraestructura.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo.Infraestructura
{
    public class JugadorRepository: GenericRepository<Jugador>, IJugadorRepository
    {
        public JugadorRepository(IDbContext context) : base(context)
        {

        }
    }
}
