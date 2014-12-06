using System;
using System.ComponentModel.DataAnnotations;

namespace webtest2.ViewModels
{
    public class TimeRegistrationViewModel
    {
        public string ProjectName { get; set; }
        public TimeSpan Time { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset Date { get; set; }
    }
}