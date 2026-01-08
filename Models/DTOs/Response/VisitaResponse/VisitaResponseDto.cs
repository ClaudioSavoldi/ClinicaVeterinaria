using ClinicaVeterinaria.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaVeterinaria.Models.DTOs.Response.VisitaResponse
{
    public class VisitaResponseDto
    {
        public Guid VisitaId { get; set; }
        public DateTime DataVisita { get; set; } = DateTime.UtcNow;
        public string EsameObiettivo { get; set; } = string.Empty;
        public string DescrizioneCura { get; set; } = string.Empty;
        public Guid AnimaleId { get; set; }

        public string NameAnimale { get; set; } = string.Empty;

        public string ProprietarioId { get; set; } = string.Empty;

        public string ProprietarioName { get; set; } = string.Empty;

    }
}

