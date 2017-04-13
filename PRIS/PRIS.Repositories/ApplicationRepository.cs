using PRIS.Core;
using PRIS.Data.Models;
using System.Linq;

namespace PRIS.Repositories
{
    public class ApplicationRepository : IApplicationRepositories
    {
        private readonly PrisEntities _db = new PrisEntities();
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
