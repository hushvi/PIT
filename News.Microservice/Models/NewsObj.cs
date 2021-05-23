using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Microservice.Models
{
    public class NewsObj
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int NewsId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime PublishedDate { get; set; }
    }
}
