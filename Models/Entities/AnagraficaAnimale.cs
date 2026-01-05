using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaVeterinaria.Models.Entities
{
    public class AnagraficaAnimale
    {

        [Key]
        public Guid AnimaleId { get; set; }

        [Required]
        public DateTime DataRegistrazione { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(50)]
        public string Tipologia { get; set; }

        [Required]
        [MaxLength(50)]
        public string ColoreMantello { get; set; }

        [Required]
        public DateTime DataNascita { get; set; }

        [Required]
        public bool PresenzaMicrochip { get; set; }

        public int? NumeroMicrochip { get; set; }

        [Required]
        [MaxLength(100)]
        public string NomeCognomeProprietario { get; set; }

        public ICollection<Visita>? Visite { get; set; }

        public Guid ProprietarioId { get; set; }
        [Required]
        [ForeignKey(nameof(ProprietarioId))]
        public Proprietario Proprietario { get; set; }

    }
}

