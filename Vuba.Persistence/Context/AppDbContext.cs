using Microsoft.EntityFrameworkCore;
using Vuba.Domain.Entities;

namespace Vuba.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Account> Account { get; set; }
        public DbSet<Episode> Episode { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Level> Level { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Season> Season { get; set; }
        public DbSet<Serie> Serie { get; set; }

    }
}
