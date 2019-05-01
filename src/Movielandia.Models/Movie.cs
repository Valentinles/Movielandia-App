using Movielandia.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movielandia.Models
{
    public class Movie
    {
        public Movie()
        {
            this.Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public Genre Genre { get; set; }

        public string Storyline { get; set; }

        public string Creator { get; set; }

        public string CoverUrl { get; set; }

        public decimal TicketPrice { get; set; }

        public int TotalTickets { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
