using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Club.Microservice.Database
{
    public class TeamObj
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int TeamId { get; set; }

        public string TeamName { get; set; }

        public string TeamAbr { get; set; }
        public string TeamGroup { get; set; }
    }
}
