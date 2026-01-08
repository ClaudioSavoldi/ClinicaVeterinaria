namespace ClinicaVeterinaria.Models.DTOs.Response.Ricovero
{
    public class ResponseRicoveriAttiviDto
    {
        public Guid RicoveroId { get; set; }

        public DateTime DataInizioRicovero { get; set; } = DateTime.UtcNow;

        public string NomeAnimale { get; set; } = string.Empty;

        public bool IsHospitalized { get; set; }
    }
}
