using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper mapper;

        public MovieService(MovielandiaDbContext context, IMapper mapper) : base(context)
        {
            this.mapper = mapper;
        }

        public bool Add(AddMovieBindingModel model)
        {
            var movie = this.mapper.Map<Movie>(model);

            this.context.Movies.Add(movie);

            this.context.SaveChanges();

            return true;
        }

        public IEnumerable<Movie> GetAll() => this.context.Movies;

        public Movie GetById(int id)
        {
            var movie = this.context.Movies.Find(id);

            return movie;
        }

        public Movie ShowDetails(int id)
        {
            var movie = this.context.Movies.FirstOrDefault(m => m.Id == id);

            return movie;
        }
    }
}
