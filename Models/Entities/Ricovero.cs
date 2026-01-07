using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaVeterinaria.Models.Entities
{
    public class Ricovero
    {

        [Key]
        public Guid RicoveroId { get; set; }

        public DateTime DataInizioRicovero { get; set; } = DateTime.UtcNow;

        public string DescrizioneAnimale { get; set; } = string.Empty;

        public Guid AnagraficaAnimaleId { get; set; }

        [ForeignKey(nameof(AnagraficaAnimaleId))]
        public AnagraficaAnimale AnagraficaAnimale { get; set; } = new();

        public bool IsHospitalized { get; set; }

    }
}
