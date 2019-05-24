using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movielandia.Common;
using Movielandia.Common.ViewModels;
using Movielandia.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Movielandia.Web.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IMovieService movieService;

        public OrdersController(IOrderService orderService, IMovieService movieService)
        {
            this.orderService = orderService;
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

        [Authorize(Roles = "Admin")]
        public IActionResult All()
        {
            var orders = this.orderService.GetAll();
 
            return View(orders);
        }

        public IActionResult MyOrders()
        {
            var myOrders = this.orderService.GetAllByUser(this.User.Identity.Name);

            return this.View(myOrders);
        }

    }
}