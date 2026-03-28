namespace CEJ_WebApp.Model
{
    public class PartyLegalProcessEntity
    {
        public string Tipo { get; set; } = "Autor";
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Profissao { get; set; }
        public string RG { get; set; }
        public bool Desconhecido { get; set; }
        public bool ExistenciaUniaoEstavel { get; set; }

        public long AddressId { get; set; } = 0;
        public AddressEntity Address { get; set; } = new AddressEntity();
    }
}
