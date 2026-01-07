using ClinicaVeterinaria.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaVeterinaria.Models.DTOs.Response.AnimaleResponse
{
    public class VisiteAnimaleResponseDto
    {
        public Guid VisitaId { get; set; }
        public DateTime DataVisita { get; set; } = DateTime.UtcNow;
        public string EsameObiettivo { get; set; } = string.Empty;
        public string DescrizioneCura { get; set; } = string.Empty;

    }
}
