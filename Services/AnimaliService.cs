using ClinicaVeterinaria.Data;
using ClinicaVeterinaria.Models.DTOs.Requests;
using ClinicaVeterinaria.Models.DTOs.Response.AnimaleResponse;
using ClinicaVeterinaria.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinaria.Services
{
    public class AnimaliService : ServiceBase
    {

        public AnimaliService(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

        //lista di animale
        public async Task<List<AnimaleResponseDto>> GetAllAnimals()
        {
            return await _context.AnagraficheAnimali
                .AsNoTracking()
                .OrderByDescending(a => a.DataRegistrazione)
                .Include(v => v.Proprietario)
                .Select(a => new AnimaleResponseDto
                {
                    AnimaleId = a.AnimaleId,
                    DataRegistrazione = a.DataRegistrazione,
                    Nome = a.Nome,
                    Tipologia = a.Tipologia,
                    ColoreMantello = a.ColoreMantello,
                    DataNascita = a.DataNascita,
                    PresenzaMicrochip = a.PresenzaMicrochip,
                    NumeroMicrochip = a.NumeroMicrochip,
                    CodiceFiscale = a.Proprietario.CodiceFiscale,
                    VisiteId = a.Visite
                    .Select(v => v.VisitaId)
                    .ToList()
                })
                .ToListAsync();
        }

        //ricerca by id animale
        public async Task<AnagraficaAnimale> GetAnimaleById(Guid id)
        {
            return await _context.AnagraficheAnimali
                 .Include(a => a.Visite)
                 .FirstOrDefaultAsync(a => a.AnimaleId == id);
        }

        //creazione animale
        public async Task<bool> CreateAnimale(AnimaleRequestDto animaleRequestDto)
        {
            var Animale = new AnagraficaAnimale
            {
                AnimaleId = Guid.NewGuid(),
                Nome = animaleRequestDto.Nome,
                Tipologia = animaleRequestDto.Tipologia,
                ColoreMantello = animaleRequestDto.ColoreMantello,
                DataNascita = animaleRequestDto.DataNascita,
                PresenzaMicrochip = animaleRequestDto.PresenzaMicrochip,
                NumeroMicrochip = animaleRequestDto.NumeroMicrochip,
                CodiceFiscale = animaleRequestDto.CodiceFiscale
            };

            _context.AnagraficheAnimali.Add(Animale);

            return await SaveAsync();
        }

        //lista visite animale in ordine dalla più recente alla meno
        public async Task<AnimaleAllVisiteResponseDto> GetAllVisiteByAnimaleId(Guid id)
        {
            var animaleById = await GetAnimaleById(id);

            AnimaleAllVisiteResponseDto anim = new AnimaleAllVisiteResponseDto
            {
                Nome = animaleById.Nome,
                Tipologia = animaleById.Tipologia,
                Visite = animaleById.Visite
                .OrderByDescending(x => x.DataVisita)
                .Select(v => new VisiteAnimaleResponseDto
                {
                    VisitaId = v.VisitaId,
                    DataVisita = v.DataVisita,
                    EsameObiettivo = v.EsameObiettivo,
                    DescrizioneCura = v.DescrizioneCura
                })
                .ToList()
            };

            return anim;

        }
    }
}
