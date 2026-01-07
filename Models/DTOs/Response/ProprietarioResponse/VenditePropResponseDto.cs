using ClinicaVeterinaria.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaVeterinaria.Models.DTOs.Response.ProprietarioResponse
{
    public class VenditePropResponseDto
    {
        public Guid VenditaId { get; set; }

        public string NomeProdotto { get; set; } = string.Empty;

        public DateTime DataVendita { get; set; } = DateTime.UtcNow;
    }
}
