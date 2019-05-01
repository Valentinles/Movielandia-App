using System;
using System.Collections.Generic;
using System.Text;

namespace Movielandia.Models
{
    public class Order
    {
        public string UserId { get; set; }

        public MovielandiaUser User { get; set; }

        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
