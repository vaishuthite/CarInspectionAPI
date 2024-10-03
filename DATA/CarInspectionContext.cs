using CarInspectionAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace CarInspectionAPI.DATA
{
    public class CarInspectionContext: DbContext
    {
        public CarInspectionContext(DbContextOptions<CarInspectionContext> options) : base(options) { }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<TechnicalTest> TechnicalTests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .HasKey(v => v.CarRegistrationNumber);

            modelBuilder.Entity<Vehicle>()
                .HasMany(v => v.TechnicalTests)
                .WithOne(t => t.Vehicle)
                .HasForeignKey(t => t.CarRegistrationNumber);


            modelBuilder.Entity<TechnicalTest>()
        .HasKey(t => t.TestId);
        }
    }
}
