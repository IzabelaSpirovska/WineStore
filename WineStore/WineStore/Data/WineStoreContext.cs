using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WineStore.Models;

namespace WineStore.Data
{
    public class WineStoreContext : DbContext
    {
        public WineStoreContext (DbContextOptions<WineStoreContext> options)
            : base(options)
        {
        }

        public DbSet<WineStore.Models.Color> Color { get; set; } = default!;

        public DbSet<WineStore.Models.Country> Country { get; set; }

        public DbSet<WineStore.Models.Region> Region { get; set; }

        public DbSet<WineStore.Models.Vintage> Vintage { get; set; }

        public DbSet<WineStore.Models.Wine> Wine { get; set; }

        public DbSet<WineStore.Models.Winery> Winery { get; set; }
    }
}
