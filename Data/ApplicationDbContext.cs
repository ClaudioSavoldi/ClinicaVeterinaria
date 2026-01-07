using ClinicaVeterinaria.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinaria.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<AnagraficaAnimale> AnagraficheAnimali { get; set; }
        public DbSet<Visita> Visite { get; set; }
        public DbSet<Prodotto> Prodotti { get; set; }
        public DbSet<Proprietario> Proprietari { get; set; }
        public DbSet<Ricovero> Ricoveri { get; set; }
        public DbSet<Armadietto> Armadietti { get; set; }
        public DbSet<Cassetto> Cassetti { get; set; }
        public DbSet<Vendita> Vendite { get; set; }
    }
}
