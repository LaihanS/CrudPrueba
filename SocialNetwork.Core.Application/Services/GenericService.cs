using AutoMapper;
using SocialNetwork.Core.Application.IRepositories;
using SocialNetwork.Core.Application.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Services
{
    public class GenericService<Entity, SaveViewModel, ViewModel> : IGenericService<Entity, SaveViewModel, ViewModel> where Entity : class
        where SaveViewModel : class
        where ViewModel : class
    {
        private readonly IMapper mapper;
        private readonly IGenericRepository<Entity> genericRepository;

        public GenericService(IMapper mapper, IGenericRepository<Entity> genericRepository)
        {
            this.mapper = mapper;
            this.genericRepository = genericRepository;
        }

        public async Task<SaveViewModel> CreateAsync(SaveViewModel viewmodel)
        {
            return mapper.Map<SaveViewModel>(await genericRepository.AddAsync(mapper.Map<Entity>(viewmodel)));
        }

        public async Task UpdateAsync(SaveViewModel viewmodel, int id)
        {
            await genericRepository.UpdateAsync(mapper.Map<Entity>(viewmodel), id);
        }

        public async Task<SaveViewModel> GetByID(int id)
        {
            return mapper.Map<SaveViewModel>(await genericRepository.GetByIDAsync(id));
        }

        public async Task<List<ViewModel>> GetAllByID()
        {
            var list = await genericRepository.GetAllAsync();
            return mapper.Map<List<ViewModel>>(list);
        }

        public async Task DeleteAsync(SaveViewModel entity)
        {
            await genericRepository.DeleteAsync(mapper.Map<Entity>(entity));
        }

    }
}
