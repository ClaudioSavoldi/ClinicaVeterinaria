using ClinicaVeterinaria.Data;
using ClinicaVeterinaria.Models.DTOs.Requests;
using ClinicaVeterinaria.Models.DTOs.Response.Prodotto;
using ClinicaVeterinaria.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinaria.Services
{
    public class ProdottoService : ServiceBase
    {

        public ProdottoService(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

        //lista dei prodotti
        public async Task<List<ResponseAllProdottiDto>> GetAllProdotti()
        {
            return await _context.Prodotti
                .AsNoTracking()
                .Select(p => new ResponseAllProdottiDto
                {
                    NomeProdotto = p.NomeProdotto,
                    DittaFornitrice = p.DittaFornitrice,
                    ElencoUsi = p.ElencoUsi,
                    NomeCassetto = p.NomeCassetto,
                    NomeArmadio = p.Cassetto.NomeArmadiettoId,
                    Vendite = p.Vendite
                    .Select(v => new VenditaProdottoDto
                    {
                        VenditaId = v.VenditaId,
                        CodiceFiscale = v.CodiceFiscale,
                        NomeCognomeCliente = $"{v.Proprietario.Nome} {v.Proprietario.Cognome}",
                        NumeroRicetta = v.NumeroRicetta,
                        DataVendita = v.DataVendita
                    })
                    .ToList()
                })
                .ToListAsync();
        }

        //ricerca posizione medicinale
        public async Task<ResponsePosizioneProdottoDto> GetPosizioneProdotto(string prodottoRicercato)
        {
            return await _context.Prodotti
                .AsNoTracking()
                .Where(p => p.NomeProdotto == prodottoRicercato)
                .Select(p => new ResponsePosizioneProdottoDto
                {
                    NomeArmadietto = p.Cassetto.NomeArmadiettoId,
                    NomeCassetto = p.NomeCassetto
                })
                .FirstOrDefaultAsync();
        }

        //creazione di un prodotto
        public async Task<bool> CreateProdotto(RequestProdottoDto request)
        {
            var newProdotto = new Prodotto
            {
                NomeProdotto = request.NomeProdotto,
                DittaFornitrice = request.DittaFornitrice,
                ElencoUsi = request.ElencoUsi,
                NomeCassetto = request.NomeCassetto
            };

            _context.Prodotti.Add(newProdotto);

            return await SaveAsync();
        }

    }
}
