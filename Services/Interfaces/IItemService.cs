using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface IItemService
    {
        void AddItem(ItemDTO obj);

        ItemDTO GetById(int id);

        IEnumerable<ItemDTO> FindAllItens();

        void Update(ItemDTO obj);

        void Remove(ItemDTO obj);

        void Dispose();
    }
}
