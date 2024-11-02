using ViewModel;

namespace ECommerce_API.Parent
{
    public interface IBaseRepository<TViewModel, TKey>
    {
        Task<VMResponse<List<TViewModel>>?> GetAllAsync(string? filter);
        Task<VMResponse<TViewModel>?> GetByIdAsync(TKey id);
        Task<VMResponse<TViewModel>?> CreateAsync(TViewModel entity);
        Task<VMResponse<TViewModel>?> UpdateAsync(TViewModel entity);
        Task<VMResponse<TViewModel>?> DeleteAsync(TKey key, int deletedBy);
    }
}
