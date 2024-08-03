using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransIT.Domain.Interfaces;
using TransIT.Domain.Models.Users;
using TransIT.Infrastructure;

namespace TransIT.Repository
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private readonly TransITContext context;

        public ClientRepository(TransITContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await context.Clients.Include(o => o.Orders).ToListAsync();
        }
        public async Task<Client?> GetById(int id)
        {
            return await context.Clients.Include(o => o.Orders).FirstOrDefaultAsync(c => c.Id==id);
        }
    }
}
