using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaVeterinaria.Models.Entities
{
    public class Vendita
    {
        [Key]
        public Guid VenditaId { get; set; }

        [MaxLength(16)]
        public string CodiceFiscale { get; set; } = string.Empty;

        [ForeignKey(nameof(CodiceFiscale))]
        public Proprietario? Proprietario { get; set; }

        public string NomeProdotto { get; set; } = string.Empty;

        [ForeignKey(nameof(NomeProdotto))]
        public Prodotto? Prodotto { get; set; }

        public int? NumeroRicetta { get; set; }

        public DateTime DataVendita { get; set; } = DateTime.UtcNow;


    }
}
