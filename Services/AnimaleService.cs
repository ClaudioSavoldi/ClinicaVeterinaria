using ClinicaVeterinaria.Data;
using ClinicaVeterinaria.Models.DTOs.Requests;
using ClinicaVeterinaria.Models.DTOs.Response.AnimaleResponse;
using ClinicaVeterinaria.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinaria.Services
{
    public class AnimaleService : ServiceBase
    {

        public AnimaleService(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

        //lista di animale
        public async Task<List<AnimaleResponseDto>> GetAllAnimals()
        {
            return await _context.AnagraficheAnimali
                .AsNoTracking()
                .Where(a => a.CodiceFiscale != null)
                .OrderByDescending(a => a.DataRegistrazione)
                //.Include(v => v.Proprietario)
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
                    .ToList(),
                    RicoveriId = a.Ricoveri
                    .Select(r => r.RicoveroId)
                    .ToList()
                })
                .ToListAsync();
        }


        //lista di animale ricoverati senza data di nascita e proprietario
        public async Task<List<AnimaleNoProprietarioResponseDto>> GetAllAnimaleSenzaProprietario()
        {
            return await _context.AnagraficheAnimali
                .AsNoTracking()
                .Where(a => a.CodiceFiscale == null)
                .OrderByDescending(a => a.DataRegistrazione)
                .Select(a => new AnimaleNoProprietarioResponseDto
                {
                    AnimaleId = a.AnimaleId,
                    DataRegistrazione = a.DataRegistrazione,
                    Nome = a.Nome,
                    Tipologia = a.Tipologia,
                    ColoreMantello = a.ColoreMantello,
                    PresenzaMicrochip = a.PresenzaMicrochip,
                    NumeroMicrochip = a.NumeroMicrochip,
                    RicoveriId = a.Ricoveri
                    .Select(r => r.RicoveroId)
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

        //creazione animale per ricovero, senza data di nascita e relazione al proprietario
        public async Task<bool> CreateAnimalePerRicovero(RequestAnimaleNoPoprietario animaleRequestDto)
        {
            var Animale = new AnagraficaAnimale
            {
                AnimaleId = Guid.NewGuid(),
                Nome = animaleRequestDto.Nome,
                Tipologia = animaleRequestDto.Tipologia,
                ColoreMantello = animaleRequestDto.ColoreMantello,
                PresenzaMicrochip = animaleRequestDto.PresenzaMicrochip,
                NumeroMicrochip = animaleRequestDto.NumeroMicrochip,
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
