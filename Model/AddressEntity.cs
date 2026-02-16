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

        [MinLength(2)]
        [MaxLength(50)]
        public string? Neighborhood { get; set; } = null!;

        [MinLength(2)]
        [MaxLength(100)]
        public string City { get; set; } = null!;

        [MinLength(2)]
        [MaxLength(50)]
        public string State { get; set; } = null!;

        [MaxLength(10)]
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
