using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.IRepositories
{
    public interface IGenericRepository<Entity> where Entity: class
    {
        Task<Entity> AddAsync(Entity entity);
        Task DeleteAsync(Entity entity);
        Task<List<Entity>> GetAllAsync();
        Task<List<Entity>> GetAllAsynWithJoin(List<string> values);
        Task<Entity> GetByIDAsync(int id);
        Task UpdateAsync(Entity entity, int id);
    }
}
