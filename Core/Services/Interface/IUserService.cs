using CEJ_WebApp.Model;
using CEJ_WebApp.Model.Dto;

namespace CEJ_WebApp.Core.Services.Interface
{
    public interface IUserService
    {
        Task<UserEntity>? GetUserByUuidAsync(Guid uuid);

        Task<List<UserEntity>>? GetUserAllAsync();

        Task<bool> AddAsync(UserEntity userEntity);

        Task<bool> EditAsync(UserEntity userEntity);

        Task<bool> DeactiveAsync(Guid userUuid);

        Task<bool> ReactiveAsync(Guid userUuid);

        Task<bool> ChangePasswordAsync(ChangePasswordResponseDto changePasswordResponseDto);

        //Task<bool> DeactiveAsync(UserEntity userEntity);
        //Task<bool> ReactiveAsync(UserEntity userEntity);
        //Task<bool> ActiveAsync(UserEntity userEntity);
    }
}