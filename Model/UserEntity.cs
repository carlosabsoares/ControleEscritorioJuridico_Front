using CEJ_WebApp.Model.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CEJ_WebApp.Model
{
    public class UserEntity
    {
        public Guid Uuid { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        public UserRoleType Role { get; set; } = UserRoleType.Operador;

        public long AddressId { get; set; } = 0;

        public  AddressEntity Address { get; set; } = new AddressEntity();
        public bool Active { get; set; } = false;
    }
}
