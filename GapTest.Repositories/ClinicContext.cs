namespace GapTest.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Models.Entities;
    using Microsoft.EntityFrameworkCore;

    public class ClinicContext : DbContext
    {
        private const string _connectionString = "Data Source=GAPClinic.db";

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
