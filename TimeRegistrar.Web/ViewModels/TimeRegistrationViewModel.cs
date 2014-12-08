using System;
using System.ComponentModel.DataAnnotations;
using TimeRegistrar.Core.Models;

namespace webtest2.ViewModels
{
    public class TimeRegistrationViewModel
    {
        public TimeRegistrationViewModel()
        {
            Date = DateTime.Now;
        }

        public string ProjectName { get; set; }
        public int ProjectId { get; set; }
        public int Id { get; set; }
        public TimeSpan Time { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public TimeRegistration ToTimeRegistration()
        {
            return new TimeRegistration(ProjectId)
            {
                Date = this.Date,
                Time = this.Time,
                Id = this.Id
            };
        }
    }
}