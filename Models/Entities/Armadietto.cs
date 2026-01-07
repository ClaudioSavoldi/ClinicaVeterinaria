using System.ComponentModel.DataAnnotations;

namespace ClinicaVeterinaria.Models.Entities
{
    public class Armadietto
    {
        [Key]
        public string NomeArmadietto { get; set; } = string.Empty;

        public ICollection<Cassetto> Cassetti { get; set; } = new List<Cassetto>();
    }
}
