using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movielandia.Common.ViewModels;
using Movielandia.Services.Interfaces;

namespace Movielandia.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IMovieService movieService;
        private readonly IMapper mapper;

        public OrdersController(IOrderService orderService, IMapper mapper, IMovieService movieService)
        {
            this.orderService = orderService;
            this.mapper = mapper;
            this.movieService = movieService;
        }

        [HttpGet]
        public IActionResult MakeOrder()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult MakeOrder(MakeOrderBindingModel model)
        {
            var result = this.orderService.MakeOrder(model, this.User.Identity.Name);
            
            if(!result)
            {
                return this.View(); 
            }

            return this.RedirectToAction("All", "Movies");
            

        }
    }
}