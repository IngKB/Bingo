using Bingo.Domain.Contracts;
using Bingo.Domain.Repositories;
using Bingo.Infraestructura.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo.Infraestructura
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly IDbContext _context;
        public UnitOfWork(IDbContext context) => _context = context;

        public int Commit()
        {
           return _context.SaveChanges();
        }
    }
}
