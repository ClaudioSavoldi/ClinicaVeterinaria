namespace ClinicaVeterinaria.Models.Entities
{
    public class Proprietario
    {
        public Guid ProprietarioId { get; set; }
        public string  NomeCompleto { get; set; }
        public string CodiceFiscale { get; set; }
        public ICollection<AnagraficaAnimale>? AnagraficheAnimali { get; set; }
      //  public ICollection<Vendita>? Vendite { get; set; }
    }
}
