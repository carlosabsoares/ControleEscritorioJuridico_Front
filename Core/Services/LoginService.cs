using Blazored.LocalStorage;
using CEJ_WebApp.Core.Request;
using CEJ_WebApp.Core.Response;
using CEJ_WebApp.Core.Services.Interface;
using CEJ_WebApp.Core.Shared;
using CEJ_WebApp.Model.Dto;
using OneOf.Types;
using System.Net.Http.Json;

namespace CEJ_WebApp.Core.Services;

public class LoginService : ILoginService
{
    private readonly HttpClient Http = new();
    private string url ;
    private bool _return = false;
    private string _object = "Authenticated";
    private readonly IUserService _userService;
    private readonly ILocalStorageService _localStorage;
    private readonly Parameters _parameters;

    public LoginService(IUserService userService, 
                        ILocalStorageService localStorage,
                        Parameters parameters)
    {
        _userService = userService;
        _localStorage = localStorage;
        _parameters = parameters;


        url = parameters.GetUrlAddress();

    }


    public async Task<LoginResponse>? Login(LoginRequest loginRequest)
    {

        var response = (await Http.PostAsJsonAsync($"{url}{_object}/Login", loginRequest));

        if (!response.IsSuccessStatusCode)
        {
            var errorResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
            return new LoginResponse
            {
                Error = errorResponse?.Error ?? "Erro desconhecido ao autenticar.",
                Expiration = string.Empty,
                NomeUsuario = string.Empty,
                Token = string.Empty
            };
        }

        var returnValue = await response.Content.ReadFromJsonAsync<AuthenticateUserDto>();

        await _localStorage.SetItemAsync("authToken", returnValue.Token);
        //await _localStorage.SetItemAsync("tokenExpiration", returnValue.Expiration);
        //await _localStorage.SetItemAsync("nomeUsuario", result.NomeUsuario);


        var userInfo = await _userService.GetUserByUuidAsync(returnValue!.User!.UserUuid);

        var _return = new LoginResponse
        {
            Error = string.Empty,
            Expiration = DateTime.UtcNow.AddHours(8).ToString(),
            NomeUsuario = returnValue!.User.Nome,
            Token = returnValue.Token,
            UserUuid = returnValue.User.UserUuid,
            CompanyUuid = returnValue.User.CompanyUuid,  
            Role = userInfo.Role
        };

        return _return;
    }
}