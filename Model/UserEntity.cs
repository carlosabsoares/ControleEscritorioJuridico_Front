using CEJ_WebApp.Model.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CEJ_WebApp.Model
{
    public class UserEntity
    {
        public Guid Uuid { get; set; }

        [Required(ErrorMessage ="Nome obrigatório")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Name { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Senha não pode ser nula")]
        [MinLength(6, ErrorMessage = "Senha deve ter no mínimo 6 dígitos")]
        [MaxLength(20, ErrorMessage = "Senha deve ter no máximo 20 dígitos")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        public UserRoleType Role { get; set; } = UserRoleType.Operador;

        public long AddressId { get; set; } = 0;

        public  AddressEntity Address { get; set; } = new AddressEntity();
        public bool Active { get; set; } = false;
        public Guid CompanyUuid { get; set; }
    }
}
