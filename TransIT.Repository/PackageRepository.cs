using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransIT.Domain.Interfaces;
using TransIT.Domain.Models;
using TransIT.Infrastructure;

namespace TransIT.Repository
{
    public class PackageRepository : Repository<Package>, IPackageRepository
    {
        private readonly TransITContext context;

        public PackageRepository(TransITContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Package> SendFromDispatcher(int id, decimal weight)
        {
            var ob = await context.Packages.FirstOrDefaultAsync(p => p.Id == id);

            ob.Status = "SPAKOVANO";
            ob.Weight = weight;
            await context.SaveChangesAsync();
            return ob;
        }
    }
}
