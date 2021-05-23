using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Team.Microservice.Models
{
    public class PlayerObj
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int PlayerId { get; set; }

        public string PlayerName { get; set; }

        public string PlayerLastName { get; set; }

        public int PlayerNumber { get; set; }

        public string PlayerBirthData { get; set; }

        public string PlayerPosition { get; set; }

        public int ClubId { get; set; }

        [ForeignKey("ClubId")]
        public TeamObj Club { get; set; }

        public int Goals { get; set; }

        public int Assists { get; set; }

        public int PenaltyMinutes { get; set; }
    }
}
