using Movielandia.Common.ViewModels;
using Movielandia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movielandia.Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrdersViewModel> GetAll();

        IEnumerable<OrdersViewModel> GetAllByUser(string username);

        bool MakeOrder(MakeOrderBindingModel model, string username);
    }
}
