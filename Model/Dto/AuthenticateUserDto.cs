namespace CEJ_WebApp.Model.Dto
{
    public class AuthenticateUserDto
    {
        public LoginUserResponseDto User { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}
