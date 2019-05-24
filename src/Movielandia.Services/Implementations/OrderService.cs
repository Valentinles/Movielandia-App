using AutoMapper;
using AutoMapper.QueryableExtensions;
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

        public OrderService(MovielandiaDbContext context) : base(context)
        {
        }

        public IEnumerable<OrdersViewModel> GetAll()
        {
            var allOrders = (from o in context.Orders
                       join m in context.Movies
                       on o.MovieId equals m.Id
                       select new OrdersViewModel
                       {
                           MovieId=m.Id,
                           Movie=m.Title,
                           User=o.User.UserName,
                           TicketCount=o.TicketCount,
                           CreatedOn=o.CreatedOn
                       });
            
            return allOrders;
        }
        public IEnumerable<OrdersViewModel> GetAllByUser(string username)
        {
            var ordersByUser=(from o in context.Orders
                          join m in context.Movies
                          on o.MovieId equals m.Id
                          where o.User.UserName==username
                          select new OrdersViewModel
                          {
                              MovieId = m.Id,
                              Movie = m.Title,
                              User = o.User.UserName,
                              TicketCount = o.TicketCount,
                              CreatedOn = o.CreatedOn
                          });
            return ordersByUser;
        }

        public bool MakeOrder(MakeOrderBindingModel model, string username)
        {
            var user = this.context.Users.SingleOrDefault(u => u.UserName == username);

            var movie = this.context.Movies.SingleOrDefault(m => m.Id == model.MovieId);

            if (user == null || movie == null || movie.TotalTickets < model.TicketCount)
            {
                return false;
            }

            var order = Mapper.Map<Order>(model);

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
