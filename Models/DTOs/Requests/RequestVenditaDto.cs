using ClinicaVeterinaria.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaVeterinaria.Models.DTOs.Requests
{
    public class RequestVenditaDto
    {
        [Required]
        public string CodiceFiscale { get; set; } = string.Empty;
        [Required]
        public string NomeProdotto { get; set; } = string.Empty;

        public int? NumeroRicetta { get; set; }

    }
}
