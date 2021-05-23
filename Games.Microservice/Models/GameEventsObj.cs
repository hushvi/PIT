using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Games.Microservice.Models
{
    public class GameEventsObj
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int EventId { get; set; }

        public string EventType { get; set; }

        public string EventTeamName { get; set; }

        public string PlayerName { get; set; }

        public string AdditionalPlayerName { get; set; }

        public int GameId { get; set; }

        [ForeignKey("GameId")]
        public GamesObj Game { get; set; }
    }
}
