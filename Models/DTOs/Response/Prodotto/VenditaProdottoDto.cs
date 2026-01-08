using ClinicaVeterinaria.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaVeterinaria.Models.DTOs.Response.Prodotto
{
    public class VenditaProdottoDto
    {
        public Guid VenditaId { get; set; }

        public string CodiceFiscale { get; set; } = string.Empty;

        public string NomeCognomeCliente { get; set; } = string.Empty;

        public int? NumeroRicetta { get; set; }

        public DateTime DataVendita { get; set; } = DateTime.UtcNow;
    }
}
