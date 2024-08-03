using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransIT.Domain.Interfaces;
using TransIT.Infrastructure;

namespace TransIT.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TransITContext context;
        public IClientRepository ClientRepository { get; private set; }

        public IOrderRepository OrderRepository { get; private set; }

        public IPackageRepository PackageRepository { get; private set; }

        public IVehicleRepository VehicleRepository { get; private set; }

        public IFactureRepository FactureRepository { get; private set; }

        public UnitOfWork(TransITContext context)
        {
            this.context = context;
            ClientRepository = new ClientRepository(context);
            OrderRepository = new OrderRepository(context);
            PackageRepository = new PackageRepository(context);
            VehicleRepository = new VehicleRepository(context);
            FactureRepository = new FactureRepository(context);
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
