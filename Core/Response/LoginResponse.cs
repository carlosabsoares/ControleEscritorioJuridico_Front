using CEJ_WebApp.Model.Enum;

namespace CEJ_WebApp.Core.Response;

public class LoginResponse
{
    public string? Error { get; set; }
    public string Token { get; set; } = string.Empty;
    public string Expiration { get; set; } = string.Empty;
    public string NomeUsuario { get; set; } = string.Empty;
    public Guid UserUuid { get; set; }
    public Guid CompanyUuid { get; set; }
    public UserRoleType Role { get; set; } = UserRoleType.Nenhum;
}
