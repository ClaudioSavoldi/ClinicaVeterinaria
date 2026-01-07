namespace ClinicaVeterinaria.Models.DTOs.Response.AnimaleResponse
{
    public class AnimaleAllVisiteResponseDto
    {
        public string Nome { get; set; } = string.Empty;

        public string Tipologia { get; set; } = string.Empty;

        public List<VisiteAnimaleResponseDto> Visite { get; set; } = new();
    }
}
