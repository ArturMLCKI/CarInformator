using CarInformator.Models;
using CarInformator.Models.Historian;
using Microsoft.EntityFrameworkCore;

namespace Carinformator.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options) { }

        public DbSet<Car> Cars { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<CarRepairHistorian> CarRepairs { get; set; }

        public DbSet<CarInsuranceHistorian> CarInsurances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            object value = modelBuilder.Entity<User>()
                .HasMany(u => u.Cars)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);


            modelBuilder.Entity<Car>()
                .HasMany(c => c.CarRepairs)
                .WithOne(u => u.RepairedCars)
                .HasForeignKey(c => c.CarId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<CarRepairHistorian>()
                .Property(c => c.Price)
                .HasPrecision(18, 4);
                

            modelBuilder.Entity<CarInsuranceHistorian>()
                .HasMany(e => e.InsuredCars)
                .WithMany(e => e.InsuranceHistorians);
                

        }

       
    }
}
