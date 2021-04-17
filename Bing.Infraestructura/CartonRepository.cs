using Bingo.Domain.Contracts;
using Bingo.Domain.Entities;
using Bingo.Domain.Repositories;
using Bingo.Infraestructura.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Bingo.Infraestructura
{
    public class CartonRepository : GenericRepository<Carton>, ICartonRepository
    {
        public CartonRepository(IDbContext context) : base(context)
        {
        }

    }
}
