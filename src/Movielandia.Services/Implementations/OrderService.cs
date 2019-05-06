using AutoMapper;
using Movielandia.Common.ViewModels;
using Movielandia.Data;
using Movielandia.Models;
using Movielandia.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movielandia.Services.Implementations
{
    public class OrderService : DataService, IOrderService
    {
        private readonly IMapper mapper;

        public OrderService(MovielandiaDbContext context, IMapper mapper) : base(context)
        {
            this.mapper = mapper;
        }


        public IEnumerable<Order> All()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> AllByUser()
        {
            throw new NotImplementedException();
        }

        public bool MakeOrder(MakeOrderBindingModel model, string userName)
        {
            var user = this.context.Users.SingleOrDefault(u => u.UserName == userName);

            var movie = this.context.Movies.SingleOrDefault(m => m.Id == model.MovieId);

            if (user == null || movie == null || movie.TotalTickets < model.TicketCount)
            {
                return false;
            }

            var order = this.mapper.Map<Order>(model);

            order.User = user;
            order.CreatedOn = DateTime.Now;

            movie.TotalTickets -= model.TicketCount;

            this.context.Movies.Update(movie);

            this.context.Orders.Add(order);

            this.context.SaveChanges();

            return true;

        }
    }
}
