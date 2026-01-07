using System.ComponentModel.DataAnnotations;

namespace ClinicaVeterinaria.Models.Entities
{
    public class Cassetto
    {
        [Key]
        public string NomeCassetto { get; set; } = string.Empty;

        public string NomeArmadiettoId { get; set; } = string.Empty;

        public Armadietto? Armadietto { get; set; }
    }
}
