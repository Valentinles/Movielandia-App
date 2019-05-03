using Movielandia.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movielandia.Services.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAll();
    }
}
