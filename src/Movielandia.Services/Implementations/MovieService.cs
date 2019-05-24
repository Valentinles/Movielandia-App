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
        //public readonly IMapper mapper;

        public MovieService(MovielandiaDbContext context) : base(context)
        {
        }

        public bool Add(AddMovieBindingModel model)
        {
            var movie = Mapper.Map<Movie>(model);

            this.context.Movies.Add(movie);

            this.context.SaveChanges();

            return true;
        }

        public void Delete(int id)
        {
            var movie = this.context.Movies.Find(id);

            this.context.Movies.Remove(movie);
            this.context.SaveChanges();
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


        public Movie Get(int id)
        {
            var movie = this.context.Movies.Find(id);

            return movie;
        }

        public void Edit(EditMovieViewModel model)
        {
            var movie = this.context.Movies.FirstOrDefault(m => m.Id == model.Id);

            movie.Title = model.Title;
            movie.Creator = model.Creator;
            movie.Storyline = model.Storyline;
            movie.Genre = model.Genre;
            movie.TicketPrice = model.TicketPrice;
            movie.TotalTickets = model.TotalTickets;

            this.context.Movies.Update(movie);
            this.context.SaveChanges();
        }
    }
}
