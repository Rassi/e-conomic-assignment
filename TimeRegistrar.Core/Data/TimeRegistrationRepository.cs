using System;
using TimeRegistrar.Core.Models;

namespace TimeRegistrar.Core.Data
{
    public interface ITimeRegistrationRepository : IRepository<TimeRegistration>
    {
    }

    public class TimeRegistrationRepository : Repository<TimeRegistration>, ITimeRegistrationRepository
    {
        private readonly IProjectRepository _projectRepository;

        public TimeRegistrationRepository(IDbContext dbContext, IProjectRepository projectRepository) : base(dbContext)
        {
            _projectRepository = projectRepository;
        }

        public override void Save(TimeRegistration entity)
        {
            var project = _projectRepository.FindById(entity.ProjectId);
            if (project == null)
            {
                throw new Exception(string.Format("Project with id '{0}' does not exist.", entity.ProjectId));
            }
            
            base.Save(entity);
        }
    }
}