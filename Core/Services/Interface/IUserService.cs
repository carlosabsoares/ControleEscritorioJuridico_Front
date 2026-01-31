using CEJ_WebApp.Model;

namespace CEJ_WebApp.Core.Services.Interface
{
    public interface IUserService
    {
        Task<UserEntity>? GetUserByUuidAsync(Guid uuid);
    }
}
