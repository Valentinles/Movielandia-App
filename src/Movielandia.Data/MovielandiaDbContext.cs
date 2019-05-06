using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Movielandia.Models;

namespace Movielandia.Data
{
    public class MovielandiaDbContext : IdentityDbContext<MovielandiaUser>
    {
        public MovielandiaDbContext(DbContextOptions<MovielandiaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Order> Orders { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Order>()
        //        .HasKey(o => new { o.UserId, o.MovieId });

        //    base.OnModelCreating(builder);
        //}
    }
}
