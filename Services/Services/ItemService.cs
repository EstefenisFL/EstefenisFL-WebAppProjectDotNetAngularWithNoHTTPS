using Domain.Models;
using ProjectWebData.Repositories;
using ProjectWebData.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ItemService : ServiceBase<ItemDTO>, IItemService
    {

        public readonly IRepositoryItem _repositoryItem;
        public ItemService(IRepositoryItem repositoryItem) : base(repositoryItem)
        {
            _repositoryItem = repositoryItem;
        }
        public void AddItem(ItemDTO newItem)
        {
            _repositoryItem.AddItem(newItem);
        }
        override
        public ItemDTO GetById(int id)
        {
            return _repositoryItem.GetById(id);
        }
        public IEnumerable<ItemDTO> FindAllItens()
        {
            return _repositoryItem.GetAllItens();
        }
        override
        public void Update(ItemDTO obj)
        {
            _repositoryItem.Update(obj);
        }
        override
        public void Remove(ItemDTO obj)
        {
            _repositoryItem.Remove(obj);
        }
    }
}
