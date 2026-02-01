using Blazored.LocalStorage;
using CEJ_WebApp.Core.Request;
using CEJ_WebApp.Core.Response;
using CEJ_WebApp.Core.Services.Interface;
using CEJ_WebApp.Model.Dto;
using Microsoft.AspNetCore.Components.Authorization;

namespace CEJ_WebApp.Core.Services;

public class AuthService : IAuthService
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly ILocalStorageService _localStorage;
    private readonly ILoginService _loginService;
    private readonly IUserService _userService;

    public AuthService(ILoginService loginService,
        AuthenticationStateProvider authenticationStateProvider,
        IUserService userService,
        ILocalStorageService localStorage)
    {
        _loginService = loginService;
        _authenticationStateProvider = authenticationStateProvider;
        _localStorage = localStorage;
        _userService = userService;
    }

    public async Task<LoginResponse>? Login(LoginRequest loginRequest)
    {
        var result = await _loginService.Login(loginRequest);

        if (result is null || string.IsNullOrEmpty(result.Token))
            return null;

        await _localStorage.SetItemAsync("tokenExpiration", result.Expiration);

        ((ApiAuthenticationStateProvider)_authenticationStateProvider)
                            .MarkUserAsAuthenticated(result.NomeUsuario);

        return result;
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("authToken");

        ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
        //httpClient.DefaultRequestHeaders.Authorization = null;
    }
}
