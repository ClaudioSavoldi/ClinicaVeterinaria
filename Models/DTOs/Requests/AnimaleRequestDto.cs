using ClinicaVeterinaria.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaVeterinaria.Models.DTOs.Requests
{
    public class AnimaleRequestDto
    {


        [Required]
        public string Nome { get; set; } = string.Empty;


        [Required]
        public string Tipologia { get; set; } = string.Empty;

        [Required]
        public string ColoreMantello { get; set; } = string.Empty;

        [Required]
        public DateOnly DataNascita { get; set; }

        [Required]
        public bool PresenzaMicrochip { get; set; }

        public int? NumeroMicrochip { get; set; }

        [Required]
        public string CodiceFiscale { get; set; } = string.Empty;
    }
}
