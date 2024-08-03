using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransIT.Domain.Interfaces;
using TransIT.Infrastructure;

namespace TransIT.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly TransITContext context;

        public Repository(TransITContext context)
        {
            this.context = context;
        }

        public async Task<T> Create(T entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                context.Remove(entity);
                await context.SaveChangesAsync();
            }
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<T> Update(int id, T entity)
        {
            var objFromDb = await context.Set<T>().FindAsync(id);
            if(objFromDb != null)
            {
                context.Entry(objFromDb).CurrentValues.SetValues(entity);
                await context.SaveChangesAsync();
            }
            return objFromDb;
        }
    }
}
