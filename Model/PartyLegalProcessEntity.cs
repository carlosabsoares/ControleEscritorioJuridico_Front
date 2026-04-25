using CEJ_WebApp.Model.Enum;

namespace CEJ_WebApp.Model
{
    public class PartyLegalProcessEntity
    {
        public Guid ProcessUuid { get; set; }
        public LegalPartyType LegalParty { get; set; } = LegalPartyType.Autor;
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Profession { get; set; }
        public string LegalRepresentative { get; set; }
        public string GeneralRegistration { get; set; }
        public bool Unknown { get; set; }
        public bool HasCommonLawMarriage { get; set; }
        public string? Position { get; set; } = string.Empty;

        public long AddressId { get; set; } = 0;
        public AddressEntity Address { get; set; } = new AddressEntity();
    }
}
