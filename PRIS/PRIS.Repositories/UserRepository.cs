using PRIS.Core;
using PRIS.Data.Models;
using System.Linq;

namespace PRIS.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PrisEntities _db = new PrisEntities();
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
