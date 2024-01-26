﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWebData.Repositories.Interfaces
{
    public interface IRepositoryItem : IRepositoryBase<ItemDTO>
    {
        IEnumerable<ItemDTO> GetAllItens();
        void AddItem(ItemDTO newItem);
    }
}
