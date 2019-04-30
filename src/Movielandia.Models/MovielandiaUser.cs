using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Movielandia.Models
{
    // Add profile data for application users by adding properties to the MovielandiaUser class
    public class MovielandiaUser : IdentityUser
    {
        public string Address { get; set; }
    }
}
