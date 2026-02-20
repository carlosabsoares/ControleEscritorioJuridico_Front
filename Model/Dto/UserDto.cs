using CEJ_WebApp.Model.Enum;

namespace CEJ_WebApp.Model.Dto
{
    public class UserDto
    {
        public Guid Uuid { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
        public bool Active { get; set; } = true;
    }
}
