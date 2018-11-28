using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RocketLeagueStatsAPI.Models;

namespace RocketLeagueStatsAPI.Models
{
    public class RocketLeagueStatsModel : DbContext
    {
        public RocketLeagueStatsModel(DbContextOptions<RocketLeagueStatsModel>options): base(options)
        {

        }

        public DbSet<team> teams { get; set; }
        public DbSet<player> players { get; set; }
    }
}
