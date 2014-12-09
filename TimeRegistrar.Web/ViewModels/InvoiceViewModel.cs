using System;

namespace TimeRegistrar.Web.ViewModels
{
    public class InvoiceViewModel
    {
        public string ProjectName { get; set; }
        public TimeSpan Time { get; set; }
    }
}