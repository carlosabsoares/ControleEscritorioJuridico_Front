using Blazored.LocalStorage;

namespace CEJ_WebApp.Core.Shared
{
    public static class Parameters
    {
        private static readonly ILocalStorageService _localStorage;

        public static string GetUrlAddress()
        {
            return "https://localhost:1602/v1/";
        }

        public static async Task<string> GetTokenAsync() {

            var savedToken = await _localStorage.GetItemAsync<string>("authToken");

            return savedToken ?? null;

        }
    }
}
