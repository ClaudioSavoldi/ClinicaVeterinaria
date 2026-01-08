using System.ComponentModel.DataAnnotations;

namespace ClinicaVeterinaria.Models.DTOs.Requests
{
    public class RequestAnimaleNoPoprietario
    {
        [Required]
        public string Nome { get; set; } = string.Empty;


        [Required]
        public string Tipologia { get; set; } = string.Empty;

        [Required]
        public string ColoreMantello { get; set; } = string.Empty;

        [Required]
        public bool PresenzaMicrochip { get; set; }

        public int? NumeroMicrochip { get; set; }

    }
}
