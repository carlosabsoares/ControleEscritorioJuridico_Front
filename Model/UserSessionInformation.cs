using CEJ_WebApp.Model.Enum;

namespace CEJ_WebApp.Model
{
    public class UserSessionInformation
    {
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
        public Guid CompanyUuid { get; set; }
        public Guid UserUuid { get; set; }
        public UserRoleType Role  { get; set; } = UserRoleType.Nenhum;
        public DateTime? ExpireJwt { get; set; } = null!;
    }
}
