using CEJ_WebApp.Model.Dto;
using CEJ_WebApp.Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace CEJ_WebApp.Model.Exemplo
{
    public class ProcessoModel
    {
        [Required]
        public string NumeroProcesso { get; set; }

        public string TipoAcao { get; set; }
        public PriorityType Prioridade { get; set; } = PriorityType.Baixa;
        public virtual ClientDto Client { get; set; } = null!;
        public string TipoAcaoDescricao { get; set; }
        public string Status { get; set; }
        public DateTime? DataAbertura { get; set; }
        public string VaraComarca { get; set; }
        public string VaraComarca2 { get; set; }
        public DateTime? PrazoProcessual { get; set; }
        public bool AtivarAlerta { get; set; }
    }
}