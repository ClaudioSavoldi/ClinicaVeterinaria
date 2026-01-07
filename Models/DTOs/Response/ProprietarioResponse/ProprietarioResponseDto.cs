namespace ClinicaVeterinaria.Models.DTOs.Response.ProprietarioResponse
{
    public class ProprietarioResponseDto
    {
        public string CodiceFiscale { get; set; } = string.Empty;

        public string Nome { get; set; } = string.Empty;

        public string Cognome { get; set; } = string.Empty;

        public List<AnimalePropResponseDto> Animali { get; set; } = new();

        public List<VenditePropResponseDto> Vendite { get; set; } = new();

    }
}
