using System.ComponentModel.DataAnnotations;

namespace CEJ_WebApp.Model
{
    public class CourtDivisionEntity
    {
        public long Id { get; set; }
        public Guid Uuid { get; init; }

        public string? Name { get; set; }
        public string? NamePt { get; set; }

        public int Code { get; set; }
        public int CourtId { get; set; }

    }
}
