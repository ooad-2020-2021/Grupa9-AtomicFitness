using AtomicFitness.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtomicFitness.Data
{
    public class ApplicationDbContext : IdentityDbContext<Korisnik>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<FitnesProfil> FitnesProfil { get; set; }
        public DbSet<FitnesProgram> FitnesProgram { get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Pjesma> Pjesma { get; set; }
        public DbSet<Recept> Recept { get; set; }
        public DbSet<Vjezba> Vjezba { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FitnesProfil>().ToTable("FitnesProfil");
            modelBuilder.Entity<FitnesProgram>().ToTable("FitnesProgram");
            modelBuilder.Entity<Korisnik>().ToTable("Korisnik");
            modelBuilder.Entity<Pjesma>().ToTable("Pjesma");
            modelBuilder.Entity<Recept>().ToTable("Recept");
            modelBuilder.Entity<Vjezba>().ToTable("Vjezba");
        }
    }
}
