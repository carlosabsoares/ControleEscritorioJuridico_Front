using CEJ_WebApp.Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace CEJ_WebApp.Model
{
    public class UserEntity
    {
        public string Name { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = null!;

        public string HashPassword { get; set; } = null!;

        public UserRoleType Role { get; set; } = UserRoleType.Operador;

        public long AddressId { get; set; } = 0;

        public AddressEntity Address { get; set; } = null!;
    }
}
