using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RocketLeagueStatsAPI.Models
{
    [Table("teams")]
    public class team
    {
        public int teamid { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(3)]
        public string region { get; set; }

        public int wins { get; set; }

        public int losses { get; set; }
    }
}
