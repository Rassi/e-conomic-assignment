using System;
using System.Collections.Generic;
using System.Linq;
using TimeRegistrar.Core.Models;

namespace TimeRegistrar.Core.Data
{
    public interface ITimeRegistrationRepository : IRepository<TimeRegistration>
    {
        IList<TimeRegistration> FindForMonth(DateTime month);
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

            if (entity.Id == default(int))
            {
                Insert(entity);
            }
            else
            {
                using (var connection = DbContext.Connection())
                {
                    var existingRecord = connection.Table<TimeRegistration>().SingleOrDefault(reg => reg.Id == entity.Id && reg.Date == entity.Date);
                    if (existingRecord == null)
                    {
                        Insert(entity);
                        return;
                    }
                }
                Update(entity);
            }
        }

        public IList<TimeRegistration> FindForMonth(DateTime month)
        {
            var monthStart = new DateTime(month.Year, month.Month, 1);
            var monthEnd = new DateTime(month.Year, month.Month, DateTime.DaysInMonth(month.Year, month.Month));
            using (var connection = DbContext.Connection())
            {
                return connection.Table<TimeRegistration>().Where(reg => reg.Date >= monthStart && reg.Date <= monthEnd).ToList();
            }
        }
    }
}