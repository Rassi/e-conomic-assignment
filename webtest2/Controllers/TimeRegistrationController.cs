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
        private readonly TimeRegistrationRepository _repository;

        public TimeRegistrationController(TimeRegistrationRepository repository)
        {
            _repository = repository;
        }

        // GET: TimeRegistration
        public ActionResult Index()
        {
            var timeRegs = _repository.FindAll();

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
            return View(_repository.FindAll());
        }

        // POST: TimeRegistration/Edit/5
        [HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        public ActionResult Edit(int id, IList<TimeRegistration> timeRegistrations, string createProject)
        {
            try
            {
                if (createProject != null)
                {
                    //_repository.Insert();
                }
                // TODO: Add update logic here


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
