using Bingo.Domain;
using Bingo.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Bing.Infraestructura
{
    public class CartonRepository : ICartonRepository
    {
        public void Add(Carton entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(List<Carton> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(Carton entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(List<Carton> entities)
        {
            throw new NotImplementedException();
        }

        public void Edit(Carton entity)
        {
            throw new NotImplementedException();
        }

        public Carton Find(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Carton> FindBy(Expression<Func<Carton, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Carton> FindBy(Expression<Func<Carton, bool>> filter = null, Func<IQueryable<Carton>, IOrderedQueryable<Carton>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public Carton FindFirstOrDefault(Expression<Func<Carton, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Carton> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
