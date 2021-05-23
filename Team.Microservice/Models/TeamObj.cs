using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Team.Microservice.Models
{
    public class TeamObj
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int TeamId { get; set; }

        public string TeamName { get; set; }

        public string TeamAbr { get; set; }

        public string TeamGroup { get; set; }

        public int GamesPlayed { get; set; }

        public int GoalsScored { get; set; }

        public int GoalsAgainst { get; set; }

        public int Points { get; set; }
    }
}
