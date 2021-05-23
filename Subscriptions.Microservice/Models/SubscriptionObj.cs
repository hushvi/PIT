using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Subscriptions.Microservice.Models
{
    public class SubscriptionObj
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int SubId { get; set; }

        public string SubscriptionEmail { get; set; }
    }
}
