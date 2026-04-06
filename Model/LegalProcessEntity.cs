using CEJ_WebApp.Model.Dto;
using CEJ_WebApp.Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace CEJ_WebApp.Model
{
    public class LegalProcessEntity
    {
        public Guid Uuid { get; set; }

        [Required]
        [RegularExpression(@"\d{7}-\d{2}\.\d{4}\.\d\.\d{2}\.\d{4}", ErrorMessage = "Número inválido")]
        public string CaseNumber { get; set; }

        public CaseActionType CaseActionType { get; set; } = CaseActionType.Civil;
        public PriorityType Priority { get; set; } = PriorityType.Baixa;
        public LegalPartyType LegalParty { get; set; }
        public virtual ClientDto Client { get; set; } = null!;
        public string CaseActionDescription { get; set; }
        public StatusProcessType Status { get; set; } = StatusProcessType.Andamento;
        public DateTime? OpenDate { get; set; }
        public int CourtDivisionCode { get; set; }
        public DateTime? LegalDeadline { get; set; }
        public bool ActivateAlert { get; set; }

        public virtual List<PartyLegalProcessEntity> PartiesLegalProcess { get; set; } = null!;
    }
}