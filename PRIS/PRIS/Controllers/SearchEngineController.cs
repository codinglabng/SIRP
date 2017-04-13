using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PRIS.Data.Models;
using PRIS.Repositories;


namespace PRIS.Controllers
{
    public class SearchEngineController : Controller
    {

        private ApplicationRepository _ApplicationRepository = new ApplicationRepository();
        // GET: SearchEngine
        public ActionResult Index(string searchString = null)
        {

            //var prisSearch = _ApplicationRepository.GetApps();


            var prisSearch = from s in _ApplicationRepository.GetApps()
                             select s;
            if (!string.IsNullOrEmpty(searchString))
            {
                prisSearch = prisSearch.Where(s => s.Name.ToLower().Contains(searchString) && s.Description.ToLower().Contains(searchString) && s.Url.Contains(searchString) && s.Author.Contains(searchString));
            }

            ViewData.Model = prisSearch;
            return View();
            //return View();
        }

        // GET: SearchEngine/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SearchEngine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SearchEngine/Create
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

        // GET: SearchEngine/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SearchEngine/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SearchEngine/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SearchEngine/Delete/5
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
