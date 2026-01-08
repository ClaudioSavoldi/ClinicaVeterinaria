using ClinicaVeterinaria.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaVeterinaria.Models.DTOs.Requests
{
    public class RequestProdottoDto
    {
        [Required]
        public string NomeProdotto { get; set; } = string.Empty;
        [Required]
        public string DittaFornitrice { get; set; } = string.Empty;
        [Required]
        public List<string> ElencoUsi { get; set; } = new List<string>();
        [Required]
        public string NomeCassetto { get; set; } = string.Empty;
    }
}
