using CEJ_WebApp.Core.Services.Interface;
using CEJ_WebApp.Core.Shared;
using CEJ_WebApp.Model;
using System.Net.Http.Json;

namespace CEJ_WebApp.Core.Services
{
    public class LegalProcessService: ILegalProcessService
    {
        private readonly HttpClient Http = new();
        private string url;
        private bool _return = false;
        private string _object = "LegalProcess";
        private readonly Parameters Parameters;
        private readonly UserSessionInformation _userSessionInformation;

        public LegalProcessService(Parameters parameters, UserSessionInformation userSessionInformation)
        {
            Parameters = parameters;
            url = Parameters.GetUrlAddress();
            _userSessionInformation = userSessionInformation;
        }

        public async Task<bool> AddAsync(LegalProcessEntity legalProcessEntity)
        {
            var _return = false;

            try
            {
                var token = await Parameters.GetTokenAsync();

                if (Http.DefaultRequestHeaders.Contains("Authorization"))
                    Http.DefaultRequestHeaders.Remove("Authorization");

                Http.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                string uri = $"{url}{_object}";

                var _result = await Http.PostAsJsonAsync($"{url}{_object}", legalProcessEntity);

                if (_result.IsSuccessStatusCode)
                    _return = true;

                return _return;
            }
            catch (Exception ex)
            {
                throw ex;
                return _return;
            }
        }
    }
}
