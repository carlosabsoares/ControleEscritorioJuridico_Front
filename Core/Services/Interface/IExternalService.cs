using CEJ_WebApp.Model;
using CEJ_WebApp.Model.Dto;

namespace CEJ_WebApp.Core.Services.Interface
{
    public interface IExternalService
    {
        Task<AddressResponseDto>? GetAddressCep(string cep);
    }
}
