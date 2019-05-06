using Movielandia.Common.ViewModels;
using Movielandia.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movielandia.Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<Order> All();

        IEnumerable<Order> AllByUser();

        bool MakeOrder(MakeOrderBindingModel model, string userName);
    }
}
