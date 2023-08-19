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
    public class RepositoryOrder : RepositoryBase<OrderDTO>, IRepositoryOrder
    {
        private readonly ApplicationContext _context;
        private readonly SQLiteContextTests _contextTest;
        public RepositoryOrder(ApplicationContext context, SQLiteContextTests contextTest) : base(context)
        {
            _context = context;
            _contextTest = contextTest;
        }
        public virtual void AddOrder(OrderDTO obj)
        {
            try
            {
                _context.Set<OrderDTO>().Add(obj);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public virtual IEnumerable<OrderDTO> GetAllOrders()
        {
            return _context.Set<OrderDTO>().ToList();
        }


        //<===========Usar _contextTest apenas para testes automatizados===========>
        //public virtual IEnumerable<OrderDTO> GetAllItens()
        //{
        //    var itens = _contextTest.GetDataBase();
        //    if (_contextTest.Set<OrderDTO>().ToList().Count == 0)
        //    {
        //        AddDataInContext(itens);
        //    }
        //    else
        //    {
        //        RemoveDataInContext(itens);
        //    }
        //    return _contextTest.Set<OrderDTO>().ToList();


        //    return _context.Set<OrderDTO>().ToList();
        //}

        //public void AddDataInContext(List<OrderDTO> clients)
        //{
        //    _context.AddRange(clients);
        //    _context.SaveChanges();
        //}
        //public void RemoveDataInContext(List<OrderDTO> clients)
        //{
        //    _context.RemoveRange(clients);
        //    _context.SaveChanges();
        //}
    }
}
