using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PRIS.Repositories;
using PRIS.Data.Models;

namespace PRIS.Controllers
{
    public class AppController : Controller
    {
        private ApplicationRepository _applicationRepository = new ApplicationRepository(); 
        // GET: App
        public ActionResult Index()
        {
            var apps = _applicationRepository.GetApps();
            return View(apps);
        }

        // GET: App/Details/5
        public ActionResult Details(int id)
        {
            var apps = _applicationRepository.GetAppsById(id);

            return View(apps);
        }

        // GET: App/Create
        public ActionResult Create()
        {
            ViewBag.AppId = new SelectList(_applicationRepository.GetApps(), "Id", "Name");
            return View();
        }

        //File Upload for Logo
        //[HttpPost]
        //public ActionResult Upload(HttpPostedFileBase logo)
        //{
        //    string directory = @"~\Content\AppLogo\";

        //    if (logo != null && logo.ContentLength > 0)
        //    {
        //        var fileName = Path.GetFileName(logo.FileName);
        //        logo.SaveAs(Path.Combine(directory, fileName));
        //    }

        //    return RedirectToAction("Index");
        //}

        // POST: App/Create
        [HttpPost]
        public ActionResult Create(App model)
        {
           
            if (string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError("", "App name cannot be empty");
                return View();
            }
            if (string.IsNullOrEmpty(model.Logo))
            {
                ModelState.AddModelError("", "Logo cannot be empty");
                return View();
            }
            if (string.IsNullOrEmpty(model.Url))
            {
                ModelState.AddModelError("", "Url cannot be empty");
                return View();
            }
            if (string.IsNullOrEmpty(model.Author))
            {
                ModelState.AddModelError("", "Author cannot be empty");
                return View();
            }
            try
            {
                // TODO: Add insert logic here
                _applicationRepository.Add(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: App/Edit/5
        public ActionResult Edit(int id)
        {
            var app = _applicationRepository.GetAppsById(id);
            return View(app);
        }

        // POST: App/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, App model)
        {
            var app = _applicationRepository.GetAppsById(id);
            if (app != null && model != null)
            {
                app.Name = model.Name;
                app.Logo = model.Logo;
                app.Url = model.Url;
                app.Description = model.Description;
                app.Author = model.Author;
                app.DateModified = model.DateModified;
                app.Status = model.Status;
            }
            try
            {
                // TODO: Add update logic here
                if(TryUpdateModel(app))
                {
                    _applicationRepository.Save();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: App/Delete/5
        public ActionResult Delete(int id)
        {
            var app = _applicationRepository.GetAppsById(id);
            return View(app);
        }

        // POST: App/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, App model)
        {
            var app = _applicationRepository.GetAppsById(id);
            try
            {
                // TODO: Add delete logic here
                _applicationRepository.Remove(app);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
