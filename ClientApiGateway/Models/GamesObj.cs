using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Games.Microservice.Models
{
    public class GamesObj
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int GameId { get; set; }

        public int FirstTeamId { get; set; }
        public int SecondTeamId { get; set; }

        public DateTime StartingTime { get; set; }

        public string GameType { get; set; }

    }
}
