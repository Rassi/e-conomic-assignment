using System;
using System.ComponentModel.DataAnnotations;
using SQLite;
using TimeRegistrar.Core.Data;

namespace TimeRegistrar.Core.Models
{
    public class TimeRegistration : Entity
    {
        [Indexed]
        public int ProjectId { get; set; }
        public TimeSpan Time { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd-MM-yy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset RegistrationDate { get; set; }

        public TimeRegistration()
        {
            RegistrationDate = DateTimeOffset.Now;
        }

        public TimeRegistration(int projectId)
        {
            ProjectId = projectId;
        }
    }
}