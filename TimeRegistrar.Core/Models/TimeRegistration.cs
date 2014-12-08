using System;
using SQLite;
using TimeRegistrar.Core.Data;

namespace TimeRegistrar.Core.Models
{
    public class TimeRegistration : Entity
    {
        [Indexed]
        public int ProjectId { get; set; }
        public TimeSpan Time { get; set; }
        
        public DateTime Date { get; set; }

        public TimeRegistration()
        {
            Date = DateTime.Now;
        }

        public TimeRegistration(int projectId)
        {
            ProjectId = projectId;
        }
    }
}