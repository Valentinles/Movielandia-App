using Movielandia.Common.Mapper;
using Movielandia.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movielandia.Common.ViewModels
{
    public class OrdersViewModel 
    {
        public int MovieId { get; set; }

        public string Movie { get; set; }

        public string User { get; set; }

        public int TicketCount { get; set; }

        public DateTime CreatedOn { get; set; }

    }
}
