using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaVeterinaria.Models.Entities
{
    public class AnagraficaAnimale
    {

        [Key]
        public Guid AnimaleId { get; set; }

        public DateTime DataRegistrazione { get; set; } = DateTime.UtcNow;

        [MaxLength(100)]
        public string Nome { get; set; } = string.Empty;


        [MaxLength(50)]
        public string Tipologia { get; set; } = string.Empty;

        [MaxLength(50)]
        public string ColoreMantello { get; set; } = string.Empty;

        public DateOnly DataNascita { get; set; }

        public bool PresenzaMicrochip { get; set; }

        [MaxLength(15)]
        public int? NumeroMicrochip { get; set; }

        [MaxLength(16)]
        public string? CodiceFiscale { get; set; }

        [ForeignKey(nameof(CodiceFiscale))]
        public Proprietario? Proprietario { get; set; }

        public ICollection<Visita>? Visite { get; set; }

        public ICollection<Ricovero>? Ricoveri { get; set; }


    }
}

