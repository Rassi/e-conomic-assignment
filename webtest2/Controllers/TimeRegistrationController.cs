using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeRegistrar.Core.Data;
using TimeRegistrar.Core.Models;

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

        // GET: TimeRegistration
        public ActionResult Index()
        {
            var timeRegs = _timeRegistrationRepository.FindAll();

            return View(timeRegs.SingleOrDefault());
        }

        // GET: TimeRegistration/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TimeRegistration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimeRegistration/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TimeRegistration/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_timeRegistrationRepository.FindAll());
        }

        // POST: TimeRegistration/Edit/5
        [HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        public ActionResult Edit(int id, IList<TimeRegistration> timeRegistrations, string createProject, string projectName)
        {
            try
            {
                if (createProject != null)
                {
                    var project = new Project(projectName);
                    _projectRepository.Insert(project);
                }

                return RedirectToAction("Edit");
            }
            catch
            {
                return View();
            }
        }

        // GET: TimeRegistration/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TimeRegistration/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
