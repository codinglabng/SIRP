using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRIS.Controllers
{
    public class SearchEngineController : Controller
    {
        // GET: SearchEngine
        public ActionResult Index()
        {
            return View();
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
