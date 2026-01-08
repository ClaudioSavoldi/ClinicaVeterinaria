using ClinicaVeterinaria.Data;
using ClinicaVeterinaria.Exceptions;
using ClinicaVeterinaria.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinaria.Helpers
{
    public class DbHelper
    {
        //metodo per l'inizializzazione del database - con tutte le chiamate ai metodi privati
        public static async Task InitializeDatabaseAsync<T>(WebApplication app) where T : DbContext
        {
            try
            {
                IServiceProvider services = app.Services;

                await RunMigrationAsync<T>(services);
                await SeedRoles(services);
                await SeedAdmin(services);
                await SeedArmadiCassetti(services);
            }
            catch
            {
                throw;
            }
        }


        //metodo per eseguire le migrazioni, se ci sono.
        private static async Task RunMigrationAsync<T>(IServiceProvider services) where T : DbContext
        {
            try
            {
                using var scope = services.CreateAsyncScope();

                var dbContext = scope.ServiceProvider.GetRequiredService<T>();

                await dbContext.Database.MigrateAsync();
            }
            catch
            {
                throw;
            }
        }


        //metodo per il seeding dei ruoli
        private static async Task SeedRoles(IServiceProvider services)
        {
            try
            {
                using var scope = services.CreateAsyncScope();

                RoleManager<IdentityRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                bool AdminRoleExists = await roleManager.RoleExistsAsync(StringConstants.AdminRole);

                IdentityRole? AdminRole = null;
                IdentityRole? veterinarioRole = null;
                IdentityRole? farmacistaRole = null;

                if (!AdminRoleExists)
                {
                    AdminRole = new IdentityRole()
                    {
                        Name = StringConstants.AdminRole,
                    };

                    IdentityResult AdminRoleCreated = await roleManager.CreateAsync(AdminRole);

                    if (!AdminRoleCreated.Succeeded)
                    {
                        throw new DbInizializationException("Errore durante la creazione del ruolo Admin");
                    }
                }
                //seeding del ruolo veterinario
                bool veterinarioRoleExists = await roleManager.RoleExistsAsync(StringConstants.VeterinarioRole);

                if (!veterinarioRoleExists)
                {
                    veterinarioRole = new IdentityRole()
                    {
                        Name = StringConstants.VeterinarioRole,
                    };

                    IdentityResult veterinarioRoleCreated = await roleManager.CreateAsync(veterinarioRole);

                    if (!veterinarioRoleCreated.Succeeded)
                    {
                        if (AdminRole != null)
                        {
                            await roleManager.DeleteAsync(AdminRole);
                        }
                        throw new DbInizializationException("Errore durante la creazione del ruolo Veterinario");
                    }
                }

                //seeding del ruolo farmacista
                bool farmacistaRoleExists = await roleManager.RoleExistsAsync(StringConstants.FarmacistaRole);

                if (!farmacistaRoleExists)
                {
                    farmacistaRole = new IdentityRole()
                    {
                        Name = StringConstants.FarmacistaRole,
                    };

                    IdentityResult farmacistaRoleCreated = await roleManager.CreateAsync(farmacistaRole);

                    if (!farmacistaRoleCreated.Succeeded)
                    {
                        if (AdminRole != null)
                        {
                            await roleManager.DeleteAsync(AdminRole);
                        }
                        throw new DbInizializationException("Errore durante la creazione del ruolo Farmacista");
                    }
                }

            }
            catch
            {
                throw;
            }
        }



        //metodo per il seeding dell'admin
        private static async Task SeedAdmin(IServiceProvider services)
        {
            try
            {
                using var scope = services.CreateAsyncScope();

                UserManager<ApplicationUser> userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                ApplicationUser? existingSuperAdmin = await userManager.FindByEmailAsync(StringConstants.AdminEmail);

                if (existingSuperAdmin == null)
                {
                    ApplicationUser Admin = new ApplicationUser()
                    {
                        Name = "Admin",
                        LastName = "Epicode",
                        Email = StringConstants.AdminEmail,
                        UserName = "AdminBuildWeek",
                        IsDeleted = false
                    };
                    //inserire la password desiderata per l'admin
                    IdentityResult userCreated = await userManager.CreateAsync(Admin, "Epicode2025!"); //QUI LA PASSWORD

                    if (!userCreated.Succeeded)
                    {
                        throw new DbInizializationException("Errore durante la creazione dell'utente Admin");
                    }

                    IdentityResult roleAssigned = await userManager.AddToRoleAsync(Admin, StringConstants.AdminRole);

                    if (!roleAssigned.Succeeded)
                    {
                        await userManager.DeleteAsync(Admin);
                        throw new DbInizializationException("Errore durante l'assegnamento del ruolo all'utente");
                    }
                }

            }
            catch
            {
                throw;
            }
        }


        //metodo per il seeding degli armadi e dei cassetti
        private static async Task SeedArmadiCassetti(IServiceProvider services)
        {
            try
            {
                using var scope = services.CreateAsyncScope();

                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                if (!await db.Armadietti.AnyAsync())
                {
                    db.Armadietti.AddRange(
                        new Armadietto { NomeArmadietto = "Alimentari" },
                        new Armadietto { NomeArmadietto = "Medicinali" }
                        );
                }


                if (!await db.Cassetti.AnyAsync())
                {
                    db.Cassetti.AddRange(
                        new Cassetto { NomeCassetto = "Alimentari1", NomeArmadiettoId = "Alimentari" },
                        new Cassetto { NomeCassetto = "Alimentari2", NomeArmadiettoId = "Alimentari" },
                        new Cassetto { NomeCassetto = "Alimentari3", NomeArmadiettoId = "Alimentari" },
                        new Cassetto { NomeCassetto = "Alimentari4", NomeArmadiettoId = "Alimentari" },
                        new Cassetto { NomeCassetto = "Alimentari5", NomeArmadiettoId = "Alimentari" },
                        new Cassetto { NomeCassetto = "Medicinali1", NomeArmadiettoId = "Medicinali" },
                        new Cassetto { NomeCassetto = "Medicinali2", NomeArmadiettoId = "Medicinali" },
                        new Cassetto { NomeCassetto = "Medicinali3", NomeArmadiettoId = "Medicinali" },
                        new Cassetto { NomeCassetto = "Medicinali4", NomeArmadiettoId = "Medicinali" },
                        new Cassetto { NomeCassetto = "Medicinali5", NomeArmadiettoId = "Medicinali" }
                        );
                }

                await db.SaveChangesAsync();

            }
            catch
            {
                throw;
            }
        }

    }
}
