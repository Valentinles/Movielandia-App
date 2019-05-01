using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Movielandia.Models
{
    public class MovielandiaUser : IdentityUser
    {
        public MovielandiaUser()
        {
            this.Orders = new HashSet<Order>();
        }

        public string MovielandiaUsername { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
