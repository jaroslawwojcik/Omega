using Omega.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Omega.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class 
    {
        public OmegaContext _context { get; set; }
        public DbSet<T> _dbSet { get; set; }

        public GenericRepository(OmegaContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

    
        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _dbSet;
            return query;
        }

        public virtual T GetSingle(long id)
        {
            return _dbSet.Find(id); 
        }

        public virtual void Save()
        {
            throw new NotImplementedException();
        }

        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
