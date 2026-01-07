using System.ComponentModel.DataAnnotations;

namespace ClinicaVeterinaria.Models.DTOs.Requests
{
    public class RequestProprietarioDto
    {
        [Required]
        public string CodiceFiscale { get; set; } = string.Empty;

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public string Cognome { get; set; } = string.Empty;
    }
}
