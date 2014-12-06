using TimeRegistrar.Core.Models;

namespace TimeRegistrar.Core.Data
{
    public interface IProjectRepository : IRepository<Project>
    {
    }

    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}