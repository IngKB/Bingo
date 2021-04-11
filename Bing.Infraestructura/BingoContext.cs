using Bingo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo.Infraestructura
{
    public class BingoContext:DbContext
    {
        public BingoContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Carton> Cartones { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySQL("server=localhost;database=pruebabingo;user=root;");
        //}
    }
}
