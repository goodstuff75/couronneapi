using DataAccess.Entities;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
   
    public class ApplicationDbContext : DbContext
{
        private static bool _created = false;

        public ApplicationDbContext()
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }


        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}
