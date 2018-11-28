using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocketLeagueStatsAPI.Models
{
    public class RocketLeagueStatsModel : DbContext
    {
        public RocketLeagueStatsModel(DbContextOptions<RocketLeagueStatsModel>options): base(options)
        {

        }
    }
}
