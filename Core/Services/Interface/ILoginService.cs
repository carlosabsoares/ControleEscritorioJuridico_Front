using CEJ_WebApp.Core.Request;
using CEJ_WebApp.Core.Response;

namespace CEJ_WebApp.Core.Services.Interface;

public interface ILoginService
{
    Task<LoginResponse>? Login(LoginRequest loginRequest);
}
