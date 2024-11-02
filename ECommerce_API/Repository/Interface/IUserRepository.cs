using ECommerce_API.Models;
using ECommerce_API.Parent;
using ViewModel;

namespace ECommerce_API.Repository.Interface
{
    public interface IUserRepository : IBaseRepository<VMMUser, int>
    {
        Task<VMResponse<VMMUser>?> RegisterAsync(VMRegister register);
        Task<VMResponse<VMMBiodata>?> LoginAsync(VMLogin login);
        Task<VMResponse<bool>?> SendOTP(VMLogin login);

    }
}
