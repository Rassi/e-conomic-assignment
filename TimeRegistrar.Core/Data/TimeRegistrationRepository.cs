using TimeRegistrar.Core.Models;

namespace TimeRegistrar.Core.Data
{
    public interface ITimeRegistrationRepository : IRepository<TimeRegistration>
    {
    }

    public class TimeRegistrationRepository : Repository<TimeRegistration>, ITimeRegistrationRepository
    {
        public TimeRegistrationRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}