using CarInformator.Models;
using CarInformator.Models.Historian;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CarInformator.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options) { }

        public DbSet<Car> Cars { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<CarRepairHistorian> CarRepairs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Cars)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Car>()
                .HasMany(c => c.CarRepairs)
                .WithOne(r => r.Cars)
                .HasForeignKey(c => c.CarId);
        }

    }
}
