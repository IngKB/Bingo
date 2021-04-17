using Bingo.Domain.Contracts;
using Bingo.Domain.Entities;
using Bingo.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Bingo.Infraestructura
{
    public class CartonRepository : ICartonRepository
    {

        private readonly BingoContext _context;

        public CartonRepository(BingoContext context)
        {
            _context = context;
        }

        public void Add(Carton Carton)
        {
            _context.Cartones.Add(Carton);
        }

        public void AddRange(List<Carton> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(Carton Carton)
        {
            _context.Cartones.Remove(Carton);
        }

        public void DeleteRange(List<Carton> entities)
        {
            throw new NotImplementedException();
        }

        public Carton Find(int numero)
        {
            var cuenta=_context.Cartones.FirstOrDefault(carton=> carton.Id==numero);
            return cuenta;
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

        public List<Carton> GetAll()
        {
            return _context.Cartones.ToList();
        }

        public void Update(Carton Carton)
        {
            _context.Cartones.Update(Carton);
        }

        IEnumerable<Carton> IGenericRepository<Carton>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
