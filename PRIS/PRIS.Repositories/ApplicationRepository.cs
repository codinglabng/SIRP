using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRIS.Core;
using PRIS.Data.Models;

namespace PRIS.Repositories
{
    public class ApplicationRepository : IApplicationRepositories
    {
        private readonly PrisDbEntities _db = new PrisDbEntities();
        public void Add(App app)
        {
            _db.Apps.Add(app);
            Save();
        }

        public IQueryable<App> GetApps()
        {
            var app = _db.Apps.OrderByDescending(e => e.Id);
            return app;
        }

        public App GetAppsById(int id)
        {
            var app = _db.Apps.FirstOrDefault(e => e.Id == id);
            return app;
        }

        public void Remove(App app)
        {
            _db.Apps.Remove(app);
            Save();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
