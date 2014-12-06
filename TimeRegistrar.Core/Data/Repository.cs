using System.Collections.Generic;
using System.Linq;

namespace TimeRegistrar.Core.Data
{
    public interface IRepository<T> where T : Entity
    {
        void Insert(T entity);
        T FindById(int id);
    }

    public class Repository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly IDbContext _dbContext;

        public Repository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Insert(T entity)
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
    }
}