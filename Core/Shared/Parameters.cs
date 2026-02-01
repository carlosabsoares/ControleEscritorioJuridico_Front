using Blazored.LocalStorage;

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
    }
}
