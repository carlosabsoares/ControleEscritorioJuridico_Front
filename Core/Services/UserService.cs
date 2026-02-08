using Blazored.LocalStorage;
using CEJ_WebApp.Core.Services.Interface;
using CEJ_WebApp.Core.Shared;
using CEJ_WebApp.Model;
using System.Net.Http.Json;

namespace CEJ_WebApp.Core.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient Http = new();
        private string url ;
        private bool _return = false;
        private string _object = "User";
        private readonly Parameters Parameters;

        public UserService(Parameters parameters)
        {
            Parameters = parameters;
            url = Parameters.GetUrlAddress();
        }

        public async Task<UserEntity>? GetUserByUuidAsync(Guid uuid)
        {
            try
            {
                UserEntity _user = new();

                var token = await Parameters.GetTokenAsync();

                if (Http.DefaultRequestHeaders.Contains("Authorization"))
                    Http.DefaultRequestHeaders.Remove("Authorization");

                Http.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                string uri = $"{url}{_object}/{uuid}/ByUuid";

                _user = await Http.GetFromJsonAsync<UserEntity>(uri);

                return _user;
            }
            catch (Exception ex)
            {
                throw ex;
                return new UserEntity();
            }
        }

        public async Task<List<UserEntity>>? GetUserAllAsync()
        {
            try
            {
                List<UserEntity> _users = new();

                var token = await Parameters.GetTokenAsync();

                if (Http.DefaultRequestHeaders.Contains("Authorization"))
                    Http.DefaultRequestHeaders.Remove("Authorization");

                Http.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                string uri = $"{url}{_object}";

                _users = await Http.GetFromJsonAsync<List<UserEntity>>(uri);

                return _users;
            }
            catch (Exception ex)
            {
                throw ex;
                return new List<UserEntity>();
            }
        }
    }
}
