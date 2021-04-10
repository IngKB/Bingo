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
        public ICartonRepository CartonRepository => throw new NotImplementedException();


        public int Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
