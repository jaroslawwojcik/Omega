using Omega.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Omega.DAL
{
    public class GenericUnitOfWork : IDisposable
    {
        private OmegaContext _omegaContext;
        public GenericUnitOfWork()
        {
            _omegaContext = new OmegaContext();
        }

        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        public IRepository<T> Repository<T>() where T : class
        {
            if(repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IRepository<T>;
            }
            IRepository<T> repo = new GenericRepository<T>(_omegaContext);
            repositories.Add(typeof(T), repo);
            return repo;
        }
        public void SaveChanges()
        {
            _omegaContext.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    _omegaContext.Dispose();
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}