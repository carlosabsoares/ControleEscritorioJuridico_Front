using CEJ_WebApp.Core.Request;
using CEJ_WebApp.Core.Response;

namespace CEJ_WebApp.Core.Services.Interface;

public interface IAuthService
{
    Task<LoginResponse>? Login(LoginRequest loginRequest);

    Task Logout();
}
