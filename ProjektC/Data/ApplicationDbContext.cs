using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjektC.Models;

namespace ProjektC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Zwierze> Zwierze { get; set; } = default!;
        public DbSet<Adopcja> Adopcja { get; set; } = default!;
        public DbSet<Lokacja> Lokacja { get; set; } = default!;
        public DbSet<Pracownik> Pracownik { get; set; } = default!;
        public DbSet<Uzytkownik> Uzytkownik { get; set; } = default!;

       

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            int result = await base.SaveChangesAsync(cancellationToken);

            await Database.ExecuteSqlRawAsync("EXEC AktualizujStatusAdopcji", cancellationToken);

            return result;
        }
    }
}
