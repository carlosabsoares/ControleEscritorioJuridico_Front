namespace CEJ_WebApp.Model
{
    public class AddressEntity
    {
        public string Street { get; set; } = null!;
        public string Number { get; set; } = null!;
        public string Complement { get; set; } = null!;
        public string? Neighborhood { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string Country { get; set; } = "Brasil";

        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public bool Deleted { get; set; } = false;
        public bool Active { get; set; } = true;
    }
}
