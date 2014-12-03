using System;

namespace webtest2.Models
{
    public class TimeRegistration
    {
        public string ProjectName { get; set; }
        public TimeSpan Time { get; set; }
        public DateTimeOffset RegistrationDate { get; set; }

        public TimeRegistration(string projectName)
        {
            ProjectName = projectName;
        }
    }
}