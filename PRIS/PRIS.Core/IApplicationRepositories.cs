using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRIS.Data.Models;

namespace PRIS.Core
{
   public interface IApplicationRepositories
    {
        void Add(App app);
        void Remove(App app);
        App GetAppsById(int Id);
        IQueryable<App> GetApps();
        void Save();

    }
}
