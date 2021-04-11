using Bingo.Domain.Contracts;
using Bingo.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo.Infraestructura
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly BingoContext _context;
        private ICartonRepository _CartonRepository;
        public ICartonRepository CartonRepository { get { return _CartonRepository ?? (_CartonRepository = new CartonRepository(_context)); } }

        public UnitOfWork(BingoContext context) => _context = context;

        public int Commit()
        {
           return _context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
