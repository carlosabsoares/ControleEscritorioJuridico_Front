namespace CEJ_WebApp.Model.Dto
{
    public class LoginUserResponseDto
    {
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public Guid CompanyUuid { get; set; }
        public Guid UserUuid { get; set; }
    }
}
