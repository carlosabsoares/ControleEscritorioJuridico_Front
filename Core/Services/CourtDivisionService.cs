using CEJ_WebApp.Core.Services.Interface;
using CEJ_WebApp.Core.Shared;
using CEJ_WebApp.Model;
using System.Net.Http.Json;

namespace CEJ_WebApp.Core.Services
{
    public class CourtDivisionService : ILegalProcessCategoryTypeService
    {
        private readonly HttpClient Http = new();
        private string url;
        private bool _return = false;
        private string _object = "CourtDivision";
        private readonly Parameters Parameters;
        private readonly UserSessionInformation _userSessionInformation;

        public CourtDivisionService(Parameters parameters, UserSessionInformation userSessionInformation)
        {
            Parameters = parameters;
            url = Parameters.GetUrlAddress();
            _userSessionInformation = userSessionInformation;
        }

        public async Task<IEnumerable<CourtDivisionEntity>> GetAll()
        {
            try
            {
                var token = await Parameters.GetTokenAsync();

                var request = new HttpRequestMessage(HttpMethod.Get, $"{url}{_object}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var response = await Http.SendAsync(request);

                response.EnsureSuccessStatusCode();

                var entity = await response.Content.ReadFromJsonAsync<List<CourtDivisionEntity>>();

                return entity ?? new List<CourtDivisionEntity>();
            }
            catch
            {
                throw;
            }
        }

        public Task<IEnumerable<CourtDivisionEntity>> GetByCategoryId(long categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<CourtDivisionEntity> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<CourtDivisionEntity> GetByUuid(Guid uuid)
        {
            throw new NotImplementedException();
        }
    }
}
