using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransIT.Domain.Models;

namespace TransIT.Domain.Interfaces
{
    public interface IPackageRepository : IRepository<Package>
    {
        Task<Package> SendFromDispatcher(int id,decimal weight);
    }
}
