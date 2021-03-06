﻿using Movielandia.Common.Mapper;
using Movielandia.Models;
using Movielandia.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movielandia.Common.ViewModels
{
    public class AllMoviesViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Genre Genre { get; set; }

        public string Storyline { get; set; }

        public string Creator { get; set; }

        public string CoverUrl { get; set; }

        public decimal TicketPrice { get; set; }

        public int TotalTickets { get; set; }
    }
}
