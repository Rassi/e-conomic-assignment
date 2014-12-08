using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TimeRegistrar.Core.Data
{
    public interface IRepository<T> where T : Entity
    {
        T FindById(int id);
        IEnumerable<T> FindAll();
        void Save(T entity);
    }

    public class Repository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly IDbContext _dbContext;

        public Repository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected void Insert(T entity)
        {
            using (var connection = _dbContext.Connection())
            {
                connection.Insert(entity);
            }
        }

        public T FindById(int id)
        {
            using (var connection = _dbContext.Connection())
            {
                return connection.Table<T>().SingleOrDefault(entity => entity.Id == id);
            }
        }

        public IEnumerable<T> FindAll()
        {
            using (var connection = _dbContext.Connection())
            {
                return connection.Table<T>().ToList();
            }
        }

        public virtual void Save(T entity)
        {
            if (entity.Id == default(int))
            {
                Insert(entity);
            }
            else
            {
                Update(entity);
            }
        }

        protected void Update(T entity)
        {
            using (var connection = _dbContext.Connection())
            {
                connection.Update(entity);
            }
        }
    }
}