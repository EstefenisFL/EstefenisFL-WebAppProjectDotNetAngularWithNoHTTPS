using Domain.Models;
using ProjectWebData.DbContexts;
using ProjectWebData.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWebData.Repositories
{
    public class RepositoryItem : RepositoryBase<ItemDTO>, IRepositoryItem
    {
        private readonly ApplicationContext _context;
        private readonly SQLiteContextTests _contextTest;
        public RepositoryItem(ApplicationContext context, SQLiteContextTests contextTest) : base(context)
        {
            _context = context;
            _contextTest = contextTest;
        }
        public virtual void AddItem(ItemDTO obj)
        {
            try
            {
                _context.Set<ItemDTO>().Add(obj);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public virtual IEnumerable<ItemDTO> GetAllItens()
        {
            return _context.Set<ItemDTO>().ToList();
        }


        //<===========Usar _contextTest apenas para testes automatizados===========>
        //public virtual IEnumerable<ItemDTO> GetAllItens()
        //{
        //    var itens = _contextTest.GetDataBase();
        //    if (_contextTest.Set<ItemDTO>().ToList().Count == 0)
        //    {
        //        AddDataInContext(itens);
        //    }
        //    else
        //    {
        //        RemoveDataInContext(itens);
        //    }
        //    return _contextTest.Set<ItemDTO>().ToList();


        //    return _context.Set<ItemDTO>().ToList();
        //}

        //public void AddDataInContext(List<ItemDTO> clients)
        //{
        //    _context.AddRange(clients);
        //    _context.SaveChanges();
        //}
        //public void RemoveDataInContext(List<ItemDTO> clients)
        //{
        //    _context.RemoveRange(clients);
        //    _context.SaveChanges();
        //}
    }
}
