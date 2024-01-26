﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWebData.Repositories.Interfaces
{
    public interface IRepositoryOrder : IRepositoryBase<OrderDTO>
    {
        IEnumerable<OrderDTO> GetAllOrders();
        void AddOrder(OrderDTO newOrder);
    }
}
