namespace ClinicaVeterinaria.Models.Entities
{
    public class ProdottoMedicinale
    {
        public Guid ProdottoMedicinaleId { get; set; }
        public string Nome { get; set; }
        public string DittaFornitrice { get; set; }
        public List<string> ElencoUsi { get; set; }

        //Gestione armadietti da decidere!!!!!
    }
}
