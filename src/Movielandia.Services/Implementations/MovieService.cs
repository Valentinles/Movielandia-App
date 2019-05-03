using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Movielandia.Common.ViewModels;
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

        public Movie ShowDetails(int id)
        {
            var movie =  this.context.Movies.FirstOrDefault(m => m.Id == id);

            return movie;
        }
    }
}
