using ClinicaVeterinaria.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaVeterinaria.Models.DTOs.Response.Ricovero
{
    public class ResponseAllRicoveriDto
    {
        public Guid RicoveroId { get; set; }

        public DateTime DataInizioRicovero { get; set; } = DateTime.UtcNow;

        public string NomeAnimale { get; set; } = string.Empty;
    }
}
