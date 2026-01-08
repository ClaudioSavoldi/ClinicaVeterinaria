using ClinicaVeterinaria.Data;
using ClinicaVeterinaria.Models.DTOs.Requests;
using ClinicaVeterinaria.Models.DTOs.Response.Vendita;
using ClinicaVeterinaria.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinaria.Services
{
    public class VenditaService : ServiceBase
    {

        public VenditaService(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

        //lista di tutte le vendite
        public async Task<List<ResponseAllVenditeDto>> GetAllVendite()
        {
            return await _context.Vendite
                .AsNoTracking()
                .Select(v => new ResponseAllVenditeDto()
                {
                    VenditaId = v.VenditaId,
                    CodiceFiscale = v.CodiceFiscale,
                    NomeProdotto = v.NomeProdotto,
                    NumeroRicetta = v.NumeroRicetta,
                    DataVendita = v.DataVendita
                })
                .ToListAsync();
        }

        //estrazione vendita medicinali in una certa data
        public async Task<List<ResponseVenditePerData>> GetVenditePerData(DateOnly dataRicerca)
        {
            var start = dataRicerca.ToDateTime(TimeOnly.MinValue);
            var end = start.AddDays(1);

            return await _context.Vendite
                .AsNoTracking()
                .Where(v => v.DataVendita >= start && v.DataVendita < end)
                .Select(v => new ResponseVenditePerData
                {
                    DataAcquisto = v.DataVendita,
                    NomeProdotto = v.NomeProdotto
                })
                .ToListAsync();

        }


        //ricerca elenco medicinali tramite codice fiscale
        public async Task<List<ResponseVenditePerCodiceFiscale>> GetVenditePerCodiceFiscale(string codiceFiscaleRicercato)
        {
            return await _context.Vendite
                .AsNoTracking()
                .Where(v => v.CodiceFiscale == codiceFiscaleRicercato)
                .Select(v => new ResponseVenditePerCodiceFiscale
                {
                    NomeProdotto = v.NomeProdotto
                })
                .ToListAsync();

        }


        //creazione di una vendita
        public async Task<bool> CreateVendita(RequestVenditaDto request)
        {

            var newVendita = new Vendita
            {
                VenditaId = Guid.NewGuid(),
                CodiceFiscale = request.CodiceFiscale,
                NomeProdotto = request.NomeProdotto,
                NumeroRicetta = request.NumeroRicetta
            };

            _context.Vendite.Add(newVendita);

            return await SaveAsync();

        }

    }
}
