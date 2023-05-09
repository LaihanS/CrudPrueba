namespace SocialNetwork.Core.Application.IServices
{
    public interface IGenericService<Entity, SaveViewModel, ViewModel>
        where Entity : class
        where SaveViewModel : class
        where ViewModel : class
    {
        Task<SaveViewModel> CreateAsync(SaveViewModel viewmodel);
        Task DeleteAsync(SaveViewModel entity);
        Task<List<ViewModel>> GetAllByID();
        Task<SaveViewModel> GetByID(int id);
        Task UpdateAsync(SaveViewModel viewmodel, int id);
    }
}