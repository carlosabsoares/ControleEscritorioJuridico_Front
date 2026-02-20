using System.ComponentModel.DataAnnotations;

namespace CEJ_WebApp.Model
{
    public class AddressEntity
    {
        [Required(ErrorMessage ="Logradouro é obrigatório")]
        [MinLength(2)]
        [MaxLength(100)]
        public string Street { get; set; } = null!;


        public string Number { get; set; } = null!;


        public string? Complement { get; set; }

        [MinLength(2, ErrorMessage = "Bairro deve ter no mínimo 2 dígitos")]
        [MaxLength(50, ErrorMessage = "Bairro deve ter no máximo 50 dígitos")]
        public string? Neighborhood { get; set; } = null!;

        [MinLength(2, ErrorMessage = "Cidade deve ter no mínimo 2 dígitos")]
        [MaxLength(100, ErrorMessage = "Cidade deve ter no máximo 100 dígitos")]
        public string City { get; set; } = null!;

        public string State { get; set; } = null!;

        [MaxLength(10,ErrorMessage = "Cep deve ter no máximo 8 dígitos")]
        public string ZipCode { get; set; } = null!;

        [MinLength(2)]
        [MaxLength(50)]
        public string Country { get; set; } = "Brasil";

        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public bool Deleted { get; set; } = false;
        public bool Active { get; set; } = true;
    }
}
