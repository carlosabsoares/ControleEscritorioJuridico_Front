using CEJ_WebApp.Core.Services.Interface;
using CEJ_WebApp.Core.Shared;
using CEJ_WebApp.Model;
using System.Net.Http.Json;
using Guid = System.Guid;

namespace CEJ_WebApp.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly HttpClient Http = new();
        private string url;
        private bool _return = false;
        private string _object = "Client";
        private readonly Parameters Parameters;
        private readonly UserSessionInformation _userSessionInformation;

        public ClientService(Parameters parameters, UserSessionInformation userSessionInformation)
        {
            Parameters = parameters;
            url = Parameters.GetUrlAddress();
            _userSessionInformation = userSessionInformation;
        }

        public async Task<bool> AddAsync(ClientEntity clientEntity)
        {
            var _return = false;

            try
            {
                clientEntity.CompanyUuid = _userSessionInformation.CompanyUuid;

                var token = await Parameters.GetTokenAsync();

                if (Http.DefaultRequestHeaders.Contains("Authorization"))
                    Http.DefaultRequestHeaders.Remove("Authorization");

                Http.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                string uri = $"{url}{_object}";

                var _result = await Http.PostAsJsonAsync($"{url}{_object}", clientEntity);

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

        public async Task<bool> DeactiveAsync(System.Guid clientUuid)
        {
            var _return = false;

            try
            {
                var token = await Parameters.GetTokenAsync();

                if (Http.DefaultRequestHeaders.Contains("Authorization"))
                    Http.DefaultRequestHeaders.Remove("Authorization");

                Http.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                string uri = $"{url}{_object}";

                var _result = await Http.DeleteAsync($"{url}{_object}?Uuid={clientUuid}");

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

        public async Task<bool> EditAsync(ClientEntity clientEntity)
        {
            var _return = false;

            try
            {
                clientEntity.CompanyUuid = _userSessionInformation.CompanyUuid;

                var token = await Parameters.GetTokenAsync();

                if (Http.DefaultRequestHeaders.Contains("Authorization"))
                    Http.DefaultRequestHeaders.Remove("Authorization");

                Http.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                string uri = $"{url}{_object}";

                var _result = await Http.PutAsJsonAsync($"{url}{_object}", clientEntity);

                if (_result.IsSuccessStatusCode)
                {
                    _return = true;
                }
                return _return;
            }
            catch (Exception ex)
            {
                throw ex;
                return _return;
            }
        }

        public async Task<List<ClientEntity>>? GetClientAllAsync()
        {
            List<ClientEntity> _clients = new();

            try
            {
                var token = await Parameters.GetTokenAsync();

                if (Http.DefaultRequestHeaders.Contains("Authorization"))
                    Http.DefaultRequestHeaders.Remove("Authorization");

                Http.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                string uri = $"{url}{_object}";

                _clients = await Http.GetFromJsonAsync<List<ClientEntity>>(uri);

                return _clients ?? null;
            }
            catch (Exception ex)
            {
                throw ex;
                return _clients;
            }
        }

        public async Task<ClientEntity>? GetClientByUuidAsync(Guid uuid)
        {
            ClientEntity _client = new();

            try
            {
                var token = await Parameters.GetTokenAsync();

                if (Http.DefaultRequestHeaders.Contains("Authorization"))
                    Http.DefaultRequestHeaders.Remove("Authorization");

                Http.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                string uri = $"{url}{_object}/{uuid}/ByUuid";

                _client = await Http.GetFromJsonAsync<ClientEntity>(uri);

                return _client;
            }
            catch (Exception ex)
            {
                throw ex;
                return _client;
            }
        }

        public async Task<bool> ReactiveAsync(Guid clientUuid)
        {
            var _return = false;

            try
            {
                var token = await Parameters.GetTokenAsync();

                if (Http.DefaultRequestHeaders.Contains("Authorization"))
                    Http.DefaultRequestHeaders.Remove("Authorization");

                Http.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                string uri = $"{url}{_object}";

                var _result = await Http.PatchAsync($"{url}{_object}?Uuid={clientUuid}", null);

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