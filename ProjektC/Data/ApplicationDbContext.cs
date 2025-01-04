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
        public DbSet<ProjektC.Models.Zwierze> Zwierze { get; set; } = default!;
        public DbSet<ProjektC.Models.Adopcja> Adopcja { get; set; } = default!;
        public DbSet<ProjektC.Models.Lokacja> Lokacja { get; set; } = default!;
        public DbSet<ProjektC.Models.Pracownik> Pracownik { get; set; } = default!;
        public DbSet<ProjektC.Models.Uzytkownik> Uzytkownik { get; set; } = default!;
    }
}
