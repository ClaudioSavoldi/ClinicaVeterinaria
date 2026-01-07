using System.ComponentModel.DataAnnotations;

namespace ClinicaVeterinaria.Models.DTOs.Response.AnimaleResponse
{
    public class AnimaleResponseDto
    {
        public Guid AnimaleId { get; set; }

        public DateTime DataRegistrazione { get; set; } = DateTime.UtcNow;

        public string Nome { get; set; } = string.Empty;

        public string Tipologia { get; set; } = string.Empty;

        public string ColoreMantello { get; set; } = string.Empty;

        public DateOnly DataNascita { get; set; }

        public bool PresenzaMicrochip { get; set; }

        public int? NumeroMicrochip { get; set; }

        public string CodiceFiscale { get; set; } = string.Empty;

        public List<Guid> VisiteId { get; set; }
    }
}
