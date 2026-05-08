namespace CEJ_WebApp.Model.Dto
{
    public class ProcessDto
    {
        public string ProcessNumber { get; set; }
        public string Status { get; set; }
        public string Client { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? LastMovimentationDate { get; set; }
        public bool Active { get; set; } = true;
    }
}