using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransIT.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public IClientRepository ClientRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IPackageRepository PackageRepository { get; }
        public IVehicleRepository VehicleRepository { get; }
        public IFactureRepository FactureRepository { get; }
        Task CompleteAsync();
    }
}
