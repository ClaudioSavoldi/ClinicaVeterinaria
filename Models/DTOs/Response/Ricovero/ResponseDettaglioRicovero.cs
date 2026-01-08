using ClinicaVeterinaria.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaVeterinaria.Models.DTOs.Response.Ricovero
{
    public class ResponseDettaglioRicovero
    {
        public Guid RicoveroId { get; set; }

        public DateTime DataInizioRicovero { get; set; } = DateTime.UtcNow;

        public string DescrizioneAnimale { get; set; } = string.Empty;

        public Guid AnagraficaAnimaleId { get; set; }

        public string NomeAnimale { get; set; } = string.Empty;

        public bool IsHospitalized { get; set; }
    }
}
