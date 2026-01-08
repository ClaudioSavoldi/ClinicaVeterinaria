namespace ClinicaVeterinaria.Models.DTOs.Response.AnimaleResponse
{
    public class AnimaleNoProprietarioResponseDto
    {
        public Guid AnimaleId { get; set; }

        public DateTime DataRegistrazione { get; set; } = DateTime.UtcNow;

        public string Nome { get; set; } = string.Empty;

        public string Tipologia { get; set; } = string.Empty;

        public string ColoreMantello { get; set; } = string.Empty;

        public bool PresenzaMicrochip { get; set; }

        public int? NumeroMicrochip { get; set; }

        public List<Guid> RicoveriId { get; set; }
    }
}
