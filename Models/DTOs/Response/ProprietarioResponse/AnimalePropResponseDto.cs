using System.ComponentModel.DataAnnotations;

namespace ClinicaVeterinaria.Models.DTOs.Response.ProprietarioResponse
{
    public class AnimalePropResponseDto
    {
        public Guid AnimaleId { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Tipologia { get; set; } = string.Empty;
    }
}
