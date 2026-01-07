using ClinicaVeterinaria.Data;
using ClinicaVeterinaria.Models.DTOs.Requests;
using ClinicaVeterinaria.Models.DTOs.Response.ProprietarioResponse;
using ClinicaVeterinaria.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinaria.Services
{
    public class ProprietarioService : ServiceBase
    {
        public ProprietarioService(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }


        //lista dei proprietari
        public async Task<List<ProprietarioResponseDto>> GetAllProprietari()
        {
            return await _context.Proprietari
                .AsNoTracking()
                .Select(p => new ProprietarioResponseDto
                {
                    CodiceFiscale = p.CodiceFiscale,
                    Nome = p.Nome,
                    Cognome = p.Cognome,
                    Animali = p.AnagraficheAnimali
                    .Select(a => new AnimalePropResponseDto
                    {
                        AnimaleId = a.AnimaleId,
                        Nome = a.Nome,
                        Tipologia = a.Tipologia
                    })
                    .ToList(),
                    Vendite = p.Vendite
                    .Select(v => new VenditePropResponseDto
                    {
                        VenditaId = v.VenditaId,
                        NomeProdotto = v.NomeProdotto,
                        DataVendita = v.DataVendita
                    })
                    .ToList(),
                })
                .ToListAsync();
        }


        //create nuovo proprietario
        public async Task<bool> CreateProprietario(RequestProprietarioDto dto)
        {
            Proprietario newProprietario = new Proprietario
            {
                CodiceFiscale = dto.CodiceFiscale,
                Nome = dto.Nome,
                Cognome = dto.Cognome
            };

            _context.Proprietari.Add(newProprietario);
            return await SaveAsync();
        }

    }
}
