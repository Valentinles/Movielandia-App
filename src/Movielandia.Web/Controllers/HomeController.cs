using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movielandia.Common.ViewModels;
using Movielandia.Services.Interfaces;
using Movielandia.Web.Models;

namespace Movielandia.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService movieService;
        private readonly IMapper mapper;

        public HomeController(IMovieService movieService, IMapper mapper)
        {
            this.movieService = movieService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {

            var movies = (this.movieService.GetAll().OrderBy(x => Guid.NewGuid())
                .Select(this.mapper.Map<AllMoviesViewModel>));

            return View(movies);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
