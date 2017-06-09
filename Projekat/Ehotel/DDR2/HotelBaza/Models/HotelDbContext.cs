using DDR2.Model;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace DDR2.HotelBaza.Models
{
    class HotelDbContext:DbContext
    {
        public DbSet<Soba> Sobe { get; set; }
        public DbSet<Gost> Gosti { get; set; }
        public DbSet<Admin> Admini { get; set; }
        public DbSet<Rezervacija> Rezervacije { get; set; }
        public DbSet<Recepcionar> Recepcionari { get; set; }
        public DbSet<Sobarica> Sobarice { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Uposlenik> Uposlenici { get; set; }
        public DbSet<Kartica> Kartice { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databaseFilePath = "FinalDataBase.db";
            try
            {
                databaseFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, databaseFilePath);
            }
            catch (InvalidOperationException) { }
            optionsBuilder.UseSqlite($"Data source={databaseFilePath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Soba>().Property(p => p.Slika).HasColumnType("image");
            base.OnModelCreating(modelBuilder);
        }
    }
}
