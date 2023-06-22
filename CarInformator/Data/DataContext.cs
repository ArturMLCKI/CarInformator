using CarInformator.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CarInformator.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options) { }

        public DbSet<Car> Cars { get; set; }

        public DbSet<User> Users { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Car>()
        //        .HasOne(u => u.User)
        //        .WithMany(c => c.Cars)
        //        .HasForeignKey(u => u.UserId);
        //}
    }
}
