using System;
using TimeRegistrar.Core.Data;

namespace TimeRegistrar.Core.Models
{
    public class TimeRegistration : Entity
    {
        public string ProjectName { get; set; }
        public TimeSpan Time { get; set; }
        public DateTimeOffset RegistrationDate { get; set; }

        public TimeRegistration()
        {
        }

        public TimeRegistration(string projectName)
        {
            ProjectName = projectName;
        }
    }
}