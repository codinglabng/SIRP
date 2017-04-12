using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PRIS.Data.Models;
using PRIS.Repositories;

namespace PRIS.Areas.Users.Controllers
{
    public class UserController : Controller
    {
       private UserRepository _UserRepo = new UserRepository();
        // GET: Users/User
        public ActionResult Index()
        {
            //var UserId = 1;
            var apps = _UserRepo.GetApps();
            return View(apps);
        }
    }
}