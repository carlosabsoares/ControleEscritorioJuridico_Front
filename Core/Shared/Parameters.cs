using Blazored.LocalStorage;
using CEJ_WebApp.Core.Services.Interface;
using CEJ_WebApp.Model;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using YamlDotNet.Core.Tokens;

namespace CEJ_WebApp.Core.Shared
{
    public class Parameters
    {
        private  readonly ILocalStorageService _localStorage;
        private UserSessionInformation _userSessionInformation;
        //private readonly IUserService _userService;

        public Parameters(ILocalStorageService localStorage, 
                          UserSessionInformation userSessionInformation
            //              IUserService userService
            )
        {
            _localStorage = localStorage;
            _userSessionInformation = userSessionInformation;
            //_userService = userService;
        }

        public  string GetUrlAddress() => "https://localhost:1602/v1/";

        public async Task<string> GetTokenAsync()
        {

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

        public void GetUserSessionInformation(string jwt)
        {
            if (string.IsNullOrEmpty(jwt))
                return;

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(jwt);

            // Captura claims específicas (sem loop)
            var uuidClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "Uuid");
            if (uuidClaim != null && Guid.TryParse(uuidClaim.Value, out var userUuid))
                _userSessionInformation.UserUuid = userUuid;

            var companyUuidClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "CompanyUuid");
            if (companyUuidClaim != null && Guid.TryParse(companyUuidClaim.Value, out var companyUuid))
                _userSessionInformation.CompanyUuid = companyUuid;

            // Expiração
            _userSessionInformation.ExpireJwt = ExpirationDateCapture(jwt);
        }


        private DateTime ExpirationDateCapture(string token)
        {
            var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var expDate = jwtToken.ValidTo; // Propriedade pronta para uso (já converte exp)
            return expDate;
        }
    }
}
