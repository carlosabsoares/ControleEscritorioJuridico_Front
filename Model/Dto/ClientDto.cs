namespace CEJ_WebApp.Model.Dto
{
    public class ClientDto
    {
        public Guid Uuid { get; set; }
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? CellPhone { get; set; }
        public bool Active { get; set; } = false;
    }
}