using System;
using System.Collections.Generic;
using System.Text;

namespace Movielandia.Common.ViewModels
{
    public class MovieOrderViewModel
    {
        public IEnumerable<AllMoviesViewModel> Movies { get; set; }
    }
}
