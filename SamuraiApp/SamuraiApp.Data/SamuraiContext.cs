using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiApp.domain;

namespace SamuraiApp.Data
{
    class SamuraiContext:DbContext
    {
        public DbSet<Samurai> Samurai { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<Quote> Quote { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=SamuraiData;Trusted_Connection=true;"
                );
        }
    }
}
