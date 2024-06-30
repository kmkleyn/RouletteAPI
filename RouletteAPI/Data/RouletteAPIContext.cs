using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RouletteAPI.Models;

namespace RouletteAPI.Data
{
    public class RouletteAPIContext : DbContext
    {
        public RouletteAPIContext (DbContextOptions<RouletteAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Bet> Bet { get; set; } = default!;
        public DbSet<BetType> BetType { get; set; } = default!;
    }
}
