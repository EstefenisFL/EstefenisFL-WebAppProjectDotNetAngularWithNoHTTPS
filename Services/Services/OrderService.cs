using Domain.Models;
using ProjectWebData.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class OrderService : ServiceBase<OrderDTO>, IOrderService
    {
        public readonly IRepositoryOrder _repositoryOrder;
        public OrderService(IRepositoryOrder repositoryOrder) : base(repositoryOrder)
        {
            _repositoryOrder = repositoryOrder;
        }
        public void AddOrder(OrderDTO newOrder)
        {
            _repositoryOrder.AddOrder(newOrder);
        }
        override
        public OrderDTO GetById(int id)
        {
            return _repositoryOrder.GetById(id);
        }
        public IEnumerable<OrderDTO> FindAllOrders()
        {
            return _repositoryOrder.GetAllOrders();
        }
    }
}
