using TimeRegistrar.Core.Models;

namespace TimeRegistrar.Core.Data
{
    public class DbSetup
    {
        private readonly IDbContext _dbContext;

        public DbSetup(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SetupDatabase()
        {
            _dbContext.Connection().CreateTable<TimeRegistration>();
        }
    }
}