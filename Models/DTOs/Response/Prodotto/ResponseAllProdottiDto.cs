using ClinicaVeterinaria.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaVeterinaria.Models.DTOs.Response.Prodotto
{
    public class ResponseAllProdottiDto
    {
        public string NomeProdotto { get; set; } = string.Empty;
        public string DittaFornitrice { get; set; } = string.Empty;
        public List<string> ElencoUsi { get; set; } = new List<string>();

        public string NomeCassetto { get; set; } = string.Empty;

        public string NomeArmadio { get; set; } = string.Empty;

        public ICollection<VenditaProdottoDto>? Vendite { get; set; }
    }
}
