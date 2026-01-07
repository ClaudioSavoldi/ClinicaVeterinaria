using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaVeterinaria.Models.Entities
{
    public class Prodotto
    {
        [Key]
        public string NomeProdotto { get; set; } = string.Empty;
        public string DittaFornitrice { get; set; } = string.Empty;
        public List<string> ElencoUsi { get; set; } = new List<string>();

        public string NomeCassetto { get; set; } = string.Empty;

        [ForeignKey(nameof(NomeCassetto))]
        public Cassetto Cassetto { get; set; } = new();

        public ICollection<Vendita>? Vendite { get; set; }
    }
}


