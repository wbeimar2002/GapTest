namespace GapTest.Repositories
{
    using Models.Entities;
    using Microsoft.EntityFrameworkCore;

    public class ClinicContext : DbContext
    {

        // cd GapTest.Repositories
        // dotnet ef migrations add InitialCreate
        // dotnet ef database update

        private const string _connectionString = "Data Source=GAPClinic.db";
        //private string _connectionString = "Data Source=" + AppContext.BaseDirectory + "GAPClinic.db";


        public DbSet<Patient> Patient { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Specialty> Specialty { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Specialty>().HasData(new Specialty { Id = 1, Name = "General Medicine" });
            modelBuilder.Entity<Specialty>().HasData(new Specialty { Id = 2, Name = "Dentistry" });
            modelBuilder.Entity<Specialty>().HasData(new Specialty { Id = 3, Name = "Pediatrics" });
            modelBuilder.Entity<Specialty>().HasData(new Specialty { Id = 4, Name = "Neurology" });
        }
    }
}
