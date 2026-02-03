using Blazored.LocalStorage;
using CEJ_WebApp.Core.Services.Interface;
using CEJ_WebApp.Core.Shared;
using CEJ_WebApp.Model;
using Microsoft.AspNetCore.Components.Authorization;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace CEJ_WebApp.Core;

public class ApiAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorage;
    private readonly Parameters _parameters;
    private readonly IUserService _userService;
    private UserSessionInformation _userSessionInformation;

    public ApiAuthenticationStateProvider(ILocalStorageService localStorage,
                                          Parameters parameters,
                                          IUserService userService,
                                          UserSessionInformation userSessionInformation)
    {
        _localStorage = localStorage;
        _parameters = parameters;
        _userService = userService;
        _userSessionInformation = userSessionInformation;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {

        //var savedToken = await _localStorage.GetItemAsync<string>("authToken");
        //var expirationToken = await _localStorage.GetItemAsync<string>("tokenExpiration");

        var savedToken = await _parameters.GetTokenAsync();
        var expirationToken = await _parameters.GetTokenExpirationAsync();

        if (string.IsNullOrWhiteSpace(savedToken) || expirationToken)
        {
            MarkUserAsLoggedOut();
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(savedToken);

        _parameters.GetUserSessionInformation(savedToken); 

        var usurInfo = await _userService.GetUserByUuidAsync(_userSessionInformation.UserUuid);

        _userSessionInformation.Nome = usurInfo.Name;
        _userSessionInformation.Email = usurInfo.Email;
        _userSessionInformation.Role = usurInfo.Role;
        _userSessionInformation.Username = usurInfo.Name.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];

        return new AuthenticationState(new ClaimsPrincipal(
           new ClaimsIdentity(ParseClaimsFromJwt(savedToken), "jwt")));
    }

    public void MarkUserAsAuthenticated(string email)
    {
        var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(new[]
        {
           new Claim(ClaimTypes.Name, email)
        }, "apiauth"));

        var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
        NotifyAuthenticationStateChanged(authState);
    }

    public void MarkUserAsLoggedOut()
    {
        var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
        var authState = Task.FromResult(new AuthenticationState(anonymousUser));
        NotifyAuthenticationStateChanged(authState);
    }

    private bool TokenExpirou(string dataToken)
    {

            if (string.IsNullOrWhiteSpace(dataToken)) return false;

            if (!DateTime.TryParseExact(
                    dataToken,
                    "yyyy-MM-dd'T'HH:mm:ss.fffffff'Z'",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.RoundtripKind,
                    out var dataExpiracao))
                return false;

            return dataExpiracao < DateTime.UtcNow;
    }
    private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var claims = new List<Claim>();
        var payload = jwt.Split('.')[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);


        keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

        if (roles != null)
        {
            if (roles.ToString().Trim().StartsWith("["))
            {
                var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());
                foreach (var parsedRole in parsedRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                }
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
            }
            keyValuePairs.Remove(ClaimTypes.Role);
        }

        claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

        return claims;
    }

    private byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }
        return Convert.FromBase64String(base64);
    }
}
