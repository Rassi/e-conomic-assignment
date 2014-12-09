using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TimeRegistrar.Core.Data;
using TimeRegistrar.Core.Models;
using TimeRegistrar.Web.ViewModels;

namespace TimeRegistrar.Web.Controllers
{
    public class TimeRegistrationController : Controller
    {
        private readonly ITimeRegistrationRepository _timeRegistrationRepository;
        private readonly IProjectRepository _projectRepository;

        public TimeRegistrationController(ITimeRegistrationRepository timeRegistrationRepository, IProjectRepository projectRepository)
        {
            _timeRegistrationRepository = timeRegistrationRepository;
            _projectRepository = projectRepository;
        }

        public ActionResult Index()
        {
            var timeRegistrationViewModels = FindTimeRegistrationsForDate(DateTime.Now);

            return View(timeRegistrationViewModels);
        }

        [HttpPost]
        public ActionResult Index(string createProject, string projectName, string searchDate, TimeRegistrationViewModel timeRegistrationViewModel)
        {
            try
            {
                if (!string.IsNullOrEmpty(createProject))
                {
                    CreateProject(projectName);
                }
                else if (!string.IsNullOrEmpty(searchDate))
                {
                    var timeRegistrationViewModels = FindTimeRegistrationsForDate(DateTime.Parse(searchDate));
                    return View(timeRegistrationViewModels);
                }
                else
                {
                    SaveTimeRegistration(timeRegistrationViewModel);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Invoice(string month, string year)
        {
            if (string.IsNullOrEmpty(month) || string.IsNullOrEmpty(year))
            {
                return View();
            }
            
            var projects = _projectRepository.FindAll();
            var monthToSearch = new DateTime(int.Parse(year), int.Parse(month), 1);
            var timeRegistrations = _timeRegistrationRepository.FindForMonth(monthToSearch).ToList();

            var invoiceViewModels = new List<InvoiceViewModel>();
            foreach (var project in projects)
            {
                var timeRegs = timeRegistrations.Where(reg => reg.ProjectId == project.Id).ToList();

                if (!timeRegs.Any())
                {
                    continue;
                }

                var invoiceViewModel = new InvoiceViewModel()
                {
                    ProjectName = project.Name,
                    Time = new TimeSpan(timeRegs.Sum(r => r.Time.Ticks)),
                };

                invoiceViewModels.Add(invoiceViewModel);
            }

            return View(invoiceViewModels);
        }

        private List<TimeRegistrationViewModel> FindTimeRegistrationsForDate(DateTime date)
        {
            var projects = _projectRepository.FindAll();
            var timeRegistrations = _timeRegistrationRepository.FindAll().ToList();

            var timeRegistrationViewModels = new List<TimeRegistrationViewModel>();
            foreach (var project in projects)
            {
                var timeRegViewModel = new TimeRegistrationViewModel()
                {
                    ProjectName = project.Name,
                    ProjectId = project.Id,
                    Date = date
                };

                var timeReg = timeRegistrations.SingleOrDefault(reg => reg.ProjectId == project.Id && reg.Date == date);

                if (timeReg != null)
                {
                    timeRegViewModel.Id = timeReg.Id;
                    timeRegViewModel.Time = timeReg.Time;
                    timeRegViewModel.Date = timeReg.Date;
                }

                timeRegistrationViewModels.Add(timeRegViewModel);
            }
            return timeRegistrationViewModels;
        }

        private void SaveTimeRegistration(TimeRegistrationViewModel timeRegistrationViewModel)
        {
            var timeRegistration = timeRegistrationViewModel.ToTimeRegistration();
            _timeRegistrationRepository.Save(timeRegistration);
        }

        private void CreateProject(string projectName)
        {
            var project = new Project(projectName);
            _projectRepository.Save(project);
        }
    }
}
