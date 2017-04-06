using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRIS.Data.Models;

namespace PRIS.Core
{
    public interface IUserRepository
    {

        App GetAppsByUserId(int Id);
        IQueryable<App> GetApps();
        Activity GetActivityUserId(int Id);
        IQueryable<Activity> GetActivity();
        

    }
}
