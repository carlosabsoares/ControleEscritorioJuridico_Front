using CEJ_WebApp.Model;

namespace CEJ_WebApp.Core.Services.Interface
{
    public interface IClientService
    {
        Task<ClientEntity>? GetClientByUuidAsync(Guid uuid);

        Task<List<ClientEntity>>? GetClientAllAsync();

        Task<bool> AddAsync(ClientEntity clientEntity);

        Task<bool> EditAsync(ClientEntity clientEntity);

        Task<bool> DeactiveAsync(Guid clientUuid);

        Task<bool> ReactiveAsync(Guid clientUuid);
    }
}