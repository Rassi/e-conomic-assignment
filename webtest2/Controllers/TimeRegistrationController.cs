using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TimeRegistrar.Core.Data;
using TimeRegistrar.Core.Models;
using webtest2.ViewModels;

namespace webtest2.Controllers
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
            var projects = _projectRepository.FindAll();
            var timeRegistrations = _timeRegistrationRepository.FindAll().ToList();

            var timeRegistrationViewModels = new List<TimeRegistrationViewModel>();
            foreach (var project in projects)
            {
                var timeRegViewModel = new TimeRegistrationViewModel()
                {
                    ProjectName = project.Name,
                    ProjectId = project.Id
                };

                var timeReg = timeRegistrations.SingleOrDefault(reg => reg.ProjectId == project.Id);

                if (timeReg != null)
                {
                    timeRegViewModel.Id = timeReg.Id;
                    timeRegViewModel.Time = timeReg.Time;
                    timeRegViewModel.Date = timeReg.Date;
                }

                timeRegistrationViewModels.Add(timeRegViewModel);
            }

            return View(timeRegistrationViewModels);
        }

        [HttpPost]
        public ActionResult Index(string createProject, string projectName, TimeRegistrationViewModel timeRegistrationViewModel)
        {
            try
            {
                if (createProject != null)
                {
                    CreateProject(projectName);
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
