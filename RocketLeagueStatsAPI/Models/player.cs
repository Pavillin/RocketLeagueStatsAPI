using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RocketLeagueStatsAPI.Models
{
    [Table("players")]
    public class player
    {
        public int playerid { get; set; }

        public int? teamid { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public int goals { get; set; }

        public int assists { get; set; }

        public int saves { get; set; }

        public int shots { get; set; }
    }
}
