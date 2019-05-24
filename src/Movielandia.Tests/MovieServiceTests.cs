using Microsoft.Extensions.DependencyInjection;
using Movielandia.Data;
using Movielandia.Services.Implementations;
using Movielandia.Services.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Movielandia.Models;
using Shouldly;
using System.Linq;
using AutoMapper;
using Movielandia.Common.Mapper;

namespace Movielandia.Tests
{
    public class MovieServiceTests
    {
        private readonly MovielandiaDbContext context;
        private readonly IMovieService service;
        private readonly IServiceProvider provider;

        public MovieServiceTests()
        {
            var services = new ServiceCollection();
            services.AddDbContext<MovielandiaDbContext>(options =>
                options.UseInMemoryDatabase(Guid.NewGuid().ToString()));
            services.AddScoped<IMovieService, MovieService>();

            this.provider = services.BuildServiceProvider();
            this.context = provider.GetService<MovielandiaDbContext>();
            this.service = provider.GetService<IMovieService>();
        }

        [Fact]
        public void GetAll_WithExistingData_ShouldReturnAllOfExistingData()
        {
            var movie = new Movie()
            {
                Title = "test",
                CoverUrl="test",
                Creator= "test",
                Storyline= "test",
                TicketPrice=1,
                TotalTickets=1
            };
            context.Movies.Add(movie);
            context.SaveChanges();

            var result = service.GetAll().Count();

            result.ShouldBe(1);
        }
    }
}
