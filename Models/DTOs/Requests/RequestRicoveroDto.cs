using ClinicaVeterinaria.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaVeterinaria.Models.DTOs.Requests
{
    public class RequestRicoveroDto
    {

        [Required]
        public string DescrizioneAnimale { get; set; } = string.Empty;

        [Required]
        public Guid AnagraficaAnimaleId { get; set; }

        [Required]
        public bool IsHospitalized { get; set; }
    }
}
