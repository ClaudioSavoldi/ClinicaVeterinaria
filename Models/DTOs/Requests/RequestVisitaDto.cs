using ClinicaVeterinaria.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaVeterinaria.Models.DTOs.Requests
{
    public class RequestVisitaDto
    {
        [Required]
        public string EsameObiettivo { get; set; } = string.Empty;
        [Required]
        public string DescrizioneCura { get; set; } = string.Empty;
        [Required]
        public Guid AnimaleId { get; set; }
    }
}

