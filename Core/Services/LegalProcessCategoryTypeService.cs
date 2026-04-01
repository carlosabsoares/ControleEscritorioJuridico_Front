using CEJ_WebApp.Core.Services.Interface;
using CEJ_WebApp.Core.Shared;
using CEJ_WebApp.Model;
using System.Net.Http.Json;

namespace CEJ_WebApp.Core.Services
{
    public class LegalProcessCategoryTypeService : ILegalProcessCategoryTypeService
    {
        private readonly HttpClient Http = new();
        private string url;
        private bool _return = false;
        private string _object = "LegalProcessCategory";
        private readonly Parameters Parameters;
        private readonly UserSessionInformation _userSessionInformation;

        public LegalProcessCategoryTypeService(Parameters parameters, UserSessionInformation userSessionInformation)
        {
            Parameters = parameters;
            url = Parameters.GetUrlAddress();
            _userSessionInformation = userSessionInformation;
        }

        public async Task<IEnumerable<LegalProcessCategoryTypeEntity>> GetAll()
        {
            try
            {
                var token = await Parameters.GetTokenAsync();

                var request = new HttpRequestMessage(HttpMethod.Get, $"{url}{_object}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var response = await Http.SendAsync(request);

                response.EnsureSuccessStatusCode();

                var entity = await response.Content.ReadFromJsonAsync<List<LegalProcessCategoryTypeEntity>>();

                return entity ?? new List<LegalProcessCategoryTypeEntity>();
            }
            catch
            {
                throw;
            }
        }

        public Task<IEnumerable<LegalProcessCategoryTypeEntity>> GetByCategoryId(long categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<LegalProcessCategoryTypeEntity> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<LegalProcessCategoryTypeEntity> GetByUuid(Guid uuid)
        {
            throw new NotImplementedException();
        }
    }
}
