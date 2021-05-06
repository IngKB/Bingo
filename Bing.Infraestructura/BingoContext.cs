using Bingo.Domain.Entities;
using Bingo.Domain.ValueObjects;
using Bingo.Infraestructura.Base;
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
    public class BingoContext : DbContextBase
    {
        public BingoContext(DbContextOptions options) : base(options)
        {
        }

        public BingoContext()
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySQL("server=localhost;database=pruebabingo;user=root;");
        //}
        public DbSet<Carton> Cartones { get; set; }
        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<PartidaBingo> Partidas { get; set; }
        public DbSet<EventoBingo> Eventos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carton>().OwnsMany(
                 p => p.Casillas, a =>
                 {
                     a.WithOwner().HasForeignKey("CartonId");
                     a.Property<int>("Id").ValueGeneratedOnAdd();
                     a.HasKey("Id");
                     a.OwnsOne(c => c.coordenada);
                 });
            modelBuilder.Entity<Jugador>().HasKey(j => j.Identificacion);

            modelBuilder.Entity<EventoBingo>()
                .HasMany(ev => ev.Partidas)
                .WithOne(par=>par.Evento);
        }


    }

}
