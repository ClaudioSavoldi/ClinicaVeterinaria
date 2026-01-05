using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaVeterinaria.Models.Entities
{
    public class Visita
    {
        [Key]
        public Guid VisitaId { get; set; }
        public string EsameObiettivo { get; set; }
        public string DescrizioneCura { get; set; }
        public Guid AnimaleId { get; set; }
        [Required]
        [ForeignKey(nameof(AnimaleId))]
        public AnagraficaAnimale AnagraficaAnimale { get; set; }
    }
}
