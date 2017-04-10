using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRIS.Core;
using PRIS.Data.Models;

namespace PRIS.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PrisDbEntities _db = new PrisDbEntities();
        public IQueryable<App> GetApps()
        {
            var apps = _db.Apps.OrderByDescending(e => e.Id);
            return apps;
        }

        public App GetAppsByUserId(int Id)
        {
            var app = _db.Apps.FirstOrDefault(e => e.Id == Id);
            return app;
        }

        public IQueryable<Activity> GetActivity()
        {
            var activity = _db.Activities.OrderByDescending(e => e.Id);
            return activity;
        }

        public Activity GetActivityUserId(int Id)
        {
            var activity = _db.Activities.FirstOrDefault(e => e.Id == e.Id);
            return activity;
        }
    }
}
