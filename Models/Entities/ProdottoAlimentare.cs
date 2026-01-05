namespace ClinicaVeterinaria.Models.Entities
{
    public class ProdottoAlimentare
    {
        
            public Guid ProdottoAlimentareId { get; set; }
            public string Nome { get; set; }
            public string DittaFornitrice { get; set; }
            public List<string> ElencoUsi { get; set; }
        }
    }


