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
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly TransITContext context;

        public OrderRepository(TransITContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Order>> GetAll()
        {
            return await context.Orders.Include(p => p.Packages).ToListAsync();
        }
        public async Task<Order?> GetById(int id)
        {
            return await context.Orders.Include(p => p.Packages).FirstOrDefaultAsync(o => o.Id == id);
        }
        public async Task<Order> CreateOrderWithPackages(Order order)
        {
            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    await context.Orders.AddAsync(order);
                    await context.SaveChangesAsync();

                    foreach (var package in order.Packages)
                    {
                        package.OrderId = order.Id;
                        await context.Packages.AddAsync(package);

                    }
                    await context.SaveChangesAsync();
                    

                    await transaction.CommitAsync();
                   
                }
                catch(Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
                return order;
            }
        }
    }
}
