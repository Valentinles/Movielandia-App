using Movielandia.Common.ViewModels;
using Movielandia.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movielandia.Services.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAll();

        Movie ShowDetails(int id);

        bool Add(AddMovieBindingModel model);
    }
}
