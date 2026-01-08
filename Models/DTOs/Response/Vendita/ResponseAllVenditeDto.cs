using ClinicaVeterinaria.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaVeterinaria.Models.DTOs.Response.Vendita
{
    public class ResponseAllVenditeDto
    {

        public Guid VenditaId { get; set; }

        public string CodiceFiscale { get; set; } = string.Empty;

        public string NomeProdotto { get; set; } = string.Empty;

        public int? NumeroRicetta { get; set; }

        public DateTime DataVendita { get; set; } = DateTime.UtcNow;
    }
}
