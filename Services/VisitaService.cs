using ClinicaVeterinaria.Data;
using ClinicaVeterinaria.Models.DTOs.Requests;
using ClinicaVeterinaria.Models.DTOs.Response.VisitaResponse;
using ClinicaVeterinaria.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinaria.Services
{
    public class VisitaService : ServiceBase
    {

        public VisitaService(ApplicationDbContext context) : base(context) { }

        //visualizzare lista visite
        public async Task<List<VisitaResponseDto>> GetAllVisite()
        {
            return await _context.Visite
                .AsNoTracking()
                //.Include(v => v.AnagraficaAnimale)
                .Select(v => new VisitaResponseDto
                {
                    VisitaId = v.AnimaleId,
                    DataVisita = v.DataVisita,
                    EsameObiettivo = v.EsameObiettivo,
                    DescrizioneCura = v.DescrizioneCura,
                    AnimaleId = v.AnimaleId,
                    NameAnimale = v.AnagraficaAnimale.Nome,
                    ProprietarioId = v.AnagraficaAnimale.Proprietario.CodiceFiscale,
                    ProprietarioName = $"{v.AnagraficaAnimale.Proprietario.Nome} {v.AnagraficaAnimale.Proprietario.Cognome}"
                })
                .ToListAsync();
        }

        //creazione di una visita
        public async Task<bool> CreateVisita(RequestVisitaDto requestVisita)
        {
            var newVisita = new Visita
            {
                VisitaId = Guid.NewGuid(),
                EsameObiettivo = requestVisita.EsameObiettivo,
                DescrizioneCura = requestVisita.DescrizioneCura,
                AnimaleId = requestVisita.AnimaleId
            };

            _context.Visite.Add(newVisita);
            return await SaveAsync();
        }

    }
}
