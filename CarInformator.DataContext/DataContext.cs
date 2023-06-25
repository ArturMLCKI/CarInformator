using CarInformator.Models;
using CarInformator.Models.Historian;
using Microsoft.EntityFrameworkCore;

namespace Carinformator.DataContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options) { }

        public DbSet<Car> Cars { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<CarRepairHistorian> CarRepairs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            object value = modelBuilder.Entity<User>()
                .HasMany(u => u.Cars)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Car>()
                .HasMany(c => c.CarRepairs)
                .WithOne(r => r.Cars)
                .HasForeignKey(c => c.CarId);
            modelBuilder.Entity<CarRepairHistorian>()
                .Property(c => c.Price);
        }

    }
}
