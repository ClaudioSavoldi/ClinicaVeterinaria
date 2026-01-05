using ClinicaVeterinaria.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinaria.Data
{
    public class ApplicationDbContext:IdentityDbContext<IdentityUser,IdentityRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<AnagraficaAnimale> AnagraficheAnimali { get; set; }
        public DbSet<Visita> Visite { get; set; }
        public DbSet<ProdottoMedicinale> ProdottiMedicinali { get; set; }
        public DbSet<ProdottoAlimentare> ProdottiALimentari{ get; set; }
        public DbSet<Proprietario> Proprietari { get; set; }
        public DbSet<Ricovero> Ricoveri { get; set; }
    }
}
