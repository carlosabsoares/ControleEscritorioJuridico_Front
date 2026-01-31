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
        private readonly string url = Parameters.GetUrlAddress();
        private bool _return = false;
        private string _object = "User";
        private readonly ILocalStorageService _localStorage;

        public UserService(ILocalStorageService localStorage) {

            var savedToken = _localStorage!.GetItemAsync<string>("authToken").Result;

            if(savedToken != null)
            {
                Http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", savedToken);
            }
        }

        public async Task<UserEntity>? GetUserByUuidAsync(Guid uuid)
        {
            try
            {
                UserEntity _user = new();

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
    }
}
