using Bingo.Domain.Entities;
using Bingo.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo.Infraestructura
{
    public class BingoContext : DbContext
    {
        //public BingoContext(DbContextOptions options) : base(options)
        //{
        //}

        //protected BingoContext()
        //{
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=pruebabingo;user=root;");
        }
        public DbSet<Carton> Cartones { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Carton>().OwnsMany(typeof(Casilla), "Casillas");
            modelBuilder.Entity<Carton>().OwnsMany(
                 p => p.Casillas, a =>
                 {
                     a.WithOwner().HasForeignKey("CartonId");
                     a.Property<int>("Id");
                     a.HasKey("Id");
                     a.OwnsOne(c => c.coordenada);
                 });
        }


    }

}
