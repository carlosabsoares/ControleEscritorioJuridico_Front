using Blazored.LocalStorage;
using System.IdentityModel.Tokens.Jwt;

namespace CEJ_WebApp.Core.Shared
{
    public  class Parameters
    {
        private  readonly ILocalStorageService _localStorage;

        public Parameters(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public  string GetUrlAddress() => "https://localhost:1602/v1/";

        public  async Task<string> GetTokenAsync() {

            var savedToken = await _localStorage.GetItemAsync<string>("authToken");

            return savedToken ?? null;

        }

        public async Task<bool> GetTokenExpirationAsync()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");

            if (string.IsNullOrEmpty(token))
                return true;

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            return jwt.ValidTo <= DateTime.UtcNow;
        }

        public async Task<DateTime?> GetTokenExpirationDateAsync()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            if (string.IsNullOrEmpty(token))
                return null;
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);
            return jwt.ValidTo;
        }
    }
}
