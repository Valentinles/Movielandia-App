using Movielandia.Models;
using Movielandia.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movielandia.Common.ViewModels
{
    public class AddMovieBindingModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "{0} The title must be between {2} and {1}.", MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [EnumDataType(typeof(Genre))]
        public Genre Genre { get; set; }

        [Required(ErrorMessage =("The storyline should not be empty."))]
        public string Storyline { get; set; }

        [Required(ErrorMessage = ("Movies must have creators."))]
        [StringLength(50, ErrorMessage = "{0} Creator's name should be between {2} and {1}.", MinimumLength = 3)]
        public string Creator { get; set; }

        [Required]
        [Url(ErrorMessage =("Please enter a valid url"))]
        public string CoverUrl { get; set; }

        [Required]
        public decimal TicketPrice { get; set; }

        [Required]
        public int TotalTickets { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
