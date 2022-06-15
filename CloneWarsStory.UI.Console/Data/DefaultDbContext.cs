using CloneWarsStory.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneWarsStory.UI.Console.Data
{
    internal class DefaultDbContext : DbContext
    {
        protected DefaultDbContext()
        {
        }

        public DefaultDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Le paramétrage des liens entre les dbsets = tables
        }

        public DbSet<Player> Players { get; set; }
    }
}
