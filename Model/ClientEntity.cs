using CEJ_WebApp.Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace CEJ_WebApp.Model
{
    public class ClientEntity
    {
        public Guid Uuid { get; set; }

        [Required(ErrorMessage = "Nome obrigatório")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Name { get; set; } = null!;

        public DocumentType DocumentType { get; set; }

        [CpfCnpjValidation]
        public string DocumentNumber { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = null!;

        [Phone]
        public string CellPhoneNumber { get; set; } = null!;

        [Phone]
        public string? PhoneNumber { get; set; } = null!;

        [MaxLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
        public string? ContactName { get; set; } = null!;

        public long AddressId { get; set; } = 0;

        [MaxLength(15, ErrorMessage = "O RG deve ter no máximo 50 caracteres.")]
        public string? GeneralRegister { get; set; }

        [MaxLength(20, ErrorMessage = "A profissao deve ter no máximo 20 caracteres.")]
        public string Profession { get; set; } =  string.Empty;

        public AddressEntity Address { get; set; } = new AddressEntity();
        public bool Active { get; set; } = false;
        public Guid CompanyUuid { get; set; }
    }
}