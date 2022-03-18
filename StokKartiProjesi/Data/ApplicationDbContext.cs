using Microsoft.EntityFrameworkCore;
using StokKartiProjesi.Models;

namespace StokKartiProjesi.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Stok> Stoklar { get; set; }

        public DbSet<Satis> Satislar { get; set; }
    }
}
