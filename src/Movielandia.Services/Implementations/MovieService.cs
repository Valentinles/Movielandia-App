using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Movielandia.Data;
using Movielandia.Models;
using Movielandia.Services.Interfaces;

namespace Movielandia.Services.Implementations
{
    public class MovieService : DataService, IMovieService
    {
        public MovieService(MovielandiaDbContext context) : base(context)
        {
        }


        public IEnumerable<Movie> GetAll() => this.context.Movies;
    }
}
