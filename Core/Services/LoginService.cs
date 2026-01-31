using CEJ_WebApp.Core.Request;
using CEJ_WebApp.Core.Response;
using CEJ_WebApp.Core.Services.Interface;
using CEJ_WebApp.Core.Shared;
using CEJ_WebApp.Model.Dto;
using System.Net.Http.Json;

namespace CEJ_WebApp.Core.Services;

public class LoginService : ILoginService
{
    private readonly HttpClient Http = new();
    private readonly string url = Parameters.GetUrlAddress();
    private bool _return = false;
    private string _object = "Authenticated";


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

        var _return = new LoginResponse
        {
            Error = string.Empty,
            Expiration = DateTime.UtcNow.AddHours(8).ToString(),
            NomeUsuario = returnValue!.User.Nome,
            Token = returnValue.Token,
            UserUuid = returnValue.User.UserUuid,
            CompanyUuid = returnValue.User.CompanyUuid,  
            Role = returnValue.User.Role
        };

        return _return;

        //if (loginRequest.Usuario == "admin" && loginRequest.Senha == "123")
        //{
        //    var retorno = new LoginResponse
        //    {
        //        Error = "",
        //        Expiration = DateTime.UtcNow.AddHours(8).ToString(),
        //        NomeUsuario = loginRequest.Usuario,
        //        Token = "1234567890asdfghjklpoiuytrewqmnbvcxz09876543210"
        //    };

        //    return retorno;
        //}
    }
}