using Movielandia.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movielandia.Common.ViewModels
{
    public class MakeOrderBindingModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public MovielandiaUser User { get; set; }

        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        [Required(ErrorMessage ="Please enter the amount.")]
        public int TicketCount { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
