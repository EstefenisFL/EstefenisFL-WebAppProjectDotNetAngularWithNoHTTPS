using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface IOrderService
    {
        void AddOrder(OrderDTO obj);

        OrderDTO GetById(int id);

        IEnumerable<OrderDTO> FindAllOrders();

        void Dispose();
    }
}
