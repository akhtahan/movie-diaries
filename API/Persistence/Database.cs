using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence
{
    public class Database : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Watchlist> Watchlist { get; set; }
        public DbSet<WatchedMovie> WatchedListDB{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("FileName=database.db");
        }

    }
}