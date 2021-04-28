using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bingo.Domain.Entities;
using Bingo.Domain.Repositories;
using Bingo.Infraestructura.Base;

namespace Bingo.Infraestructura
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IDbContext context) : base(context)
        {

        }
    }
}
