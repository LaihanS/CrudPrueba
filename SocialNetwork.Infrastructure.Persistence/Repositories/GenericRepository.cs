using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.Application.IRepositories;
using SocialNetwork.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        private readonly ApplicationContext context;

        public GenericRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<Entity> AddAsync(Entity entity)
        {
            await context.Set<Entity>().AddAsync(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(Entity entity)
        {
            context.Set<Entity>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<Entity> GetByIDAsync(int id)
        {
            Entity ent = await context.Set<Entity>().FindAsync(id);
            return ent;
        }

        public async Task UpdateAsync(Entity entity, int id)
        {
            Entity ent = await context.Set<Entity>().FindAsync(id);
            context.Entry(ent).CurrentValues.SetValues(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<Entity>> GetAllAsync()
        {
            return await context.Set<Entity>().ToListAsync();
        }

        public async Task<List<Entity>> GetAllAsynWithJoin(List<string> values)
        {
            var query = context.Set<Entity>().AsQueryable();

            foreach (string item in values)
            {
                query = query.Include(item);
            }

            return await query.ToListAsync();
        }


    }
}
