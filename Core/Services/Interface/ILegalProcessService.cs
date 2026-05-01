using CEJ_WebApp.Model;

namespace CEJ_WebApp.Core.Services.Interface
{
    public interface ILegalProcessService
    {

        Task<bool> AddAsync(LegalProcessEntity clientEntity);
        Task<IEnumerable<LegalProcessEntity>> GetAllLegalProcessAsync();
    }
}
