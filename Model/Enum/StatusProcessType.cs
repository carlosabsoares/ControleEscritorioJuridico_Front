using System.ComponentModel.DataAnnotations;

namespace CEJ_WebApp.Model.Enum
{
    public enum StatusProcessType
    {
        [Display(Name = "Em andamento")]
        Andamento = 1,

        [Display(Name = "Suspenso")]
        Suspenso = 2,

        [Display(Name = "Finalizado")]
        Finalizado = 3,

        [Display(Name = "Arquivado")]
        Arquivado = 4
    }
}
