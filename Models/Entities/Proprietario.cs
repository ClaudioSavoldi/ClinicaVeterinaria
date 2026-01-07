using System.ComponentModel.DataAnnotations;

namespace ClinicaVeterinaria.Models.Entities
{
    public class Proprietario
    {
        [Key]
        [MaxLength(16)]
        public string CodiceFiscale { get; set; } = string.Empty;

        public string Nome { get; set; } = string.Empty;

        public string Cognome { get; set; } = string.Empty;

        public ICollection<AnagraficaAnimale>? AnagraficheAnimali { get; set; }

        public ICollection<Vendita>? Vendite { get; set; }
    }
}
