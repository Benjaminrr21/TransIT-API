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
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(TransITContext context) : base(context)
        {
        }
    }
}
