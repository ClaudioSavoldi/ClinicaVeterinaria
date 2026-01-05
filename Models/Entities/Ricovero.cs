using System.ComponentModel.DataAnnotations;

namespace ClinicaVeterinaria.Models.Entities
{
    public class Ricovero
    {

        [Key]
        public Guid RicoveroId { get; set; }

        [Required]
        public DateTime DataInizioRicovero { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(50)]
        public string Tipologia { get; set; }

        [Required]
        public DateTime? DataNascita { get; set; }

        [Required]
        public bool PresenzaMicrochip { get; set; }

        public int? NumeroMicrochip { get; set; }

        [Required]
        [MaxLength(100)]
        public string DescrizioneAnimale { get; set; }

    }
}
