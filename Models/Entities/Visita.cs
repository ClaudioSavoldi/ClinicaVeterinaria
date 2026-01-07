using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaVeterinaria.Models.Entities
{
    public class Visita
    {
        [Key]
        public Guid VisitaId { get; set; }
        public DateTime DataVisita { get; set; } = DateTime.UtcNow;
        public string EsameObiettivo { get; set; } = string.Empty;
        public string DescrizioneCura { get; set; } = string.Empty;
        public Guid AnimaleId { get; set; }
        [ForeignKey(nameof(AnimaleId))]
        public AnagraficaAnimale AnagraficaAnimale { get; set; } = new();
    }
}
