using ClinicaVeterinaria.Data;
using ClinicaVeterinaria.Models.DTOs.Requests;
using ClinicaVeterinaria.Models.DTOs.Response.Ricovero;
using ClinicaVeterinaria.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinaria.Services
{
    public class RicoveroService : ServiceBase
    {
        public RicoveroService(ApplicationDbContext context) : base(context) { }

        //lista di tutti i ricoveri
        public async Task<List<ResponseAllRicoveriDto>> GetAllRicoveri()
        {
            return await _context.Ricoveri
                .AsNoTracking()
                .Select(r => new ResponseAllRicoveriDto
                {
                    RicoveroId = r.RicoveroId,
                    DataInizioRicovero = r.DataInizioRicovero,
                    NomeAnimale = r.AnagraficaAnimale.Nome
                })
                .ToListAsync();
        }

        //lista dei ricoveri attivi
        public async Task<List<ResponseRicoveriAttiviDto>> GetAllRicoveriAttivi()
        {
            return await _context.Ricoveri
                .AsNoTracking()
                .Select(r => new ResponseRicoveriAttiviDto
                {
                    RicoveroId = r.RicoveroId,
                    DataInizioRicovero = r.DataInizioRicovero,
                    NomeAnimale = r.AnagraficaAnimale.Nome,
                    IsHospitalized = r.IsHospitalized
                })
                .ToListAsync();
        }

        //visualizzare dettaglio ricovero con id
        public async Task<ResponseDettaglioRicovero> GetRicoveroById(Guid id)
        {
            return await _context.Ricoveri
                .AsNoTracking()
                .Select(r => new ResponseDettaglioRicovero
                {
                    RicoveroId = r.RicoveroId,
                    DataInizioRicovero = r.DataInizioRicovero,
                    DescrizioneAnimale = r.DescrizioneAnimale,
                    AnagraficaAnimaleId = r.AnagraficaAnimaleId,
                    NomeAnimale = r.AnagraficaAnimale.Nome,
                    IsHospitalized = r.IsHospitalized
                })
                .FirstOrDefaultAsync(r => r.RicoveroId == id);
        }

        //contabilizzazione dei rimborsi
        public async Task<ResponseContabilizzazioneRicoveri> GetContabilizzazioneRicoveri()
        {
            var ricoveriId = await _context.Ricoveri
                .AsNoTracking()
                .Select(r => r.RicoveroId)
                .ToListAsync();

            return new ResponseContabilizzazioneRicoveri
            {
                RicoveriId = ricoveriId,
                NumeroRicoveri = ricoveriId.Count
            };
        }

        //creazione di un ricovero
        public async Task<bool> CreateRicovero(RequestCreateRicoveroDto request)
        {
            var newRicovero = new Ricovero
            {
                RicoveroId = Guid.NewGuid(),
                DescrizioneAnimale = request.DescrizioneAnimale,
                AnagraficaAnimaleId = request.AnagraficaAnimaleId,
                IsHospitalized = request.IsHospitalized
            };

            _context.Ricoveri.Add(newRicovero);

            return await SaveAsync();
        }


    }
}
