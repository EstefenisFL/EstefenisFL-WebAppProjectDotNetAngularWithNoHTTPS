using Domain.Models;
using Microsoft.EntityFrameworkCore;
using ProjectWebData.DbContexts;
using ProjectWebData.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace ProjectWebData.Repositories
{
    public class RepositoryClient : RepositoryBase<ClientDTO>, IRepositoryClient
    {
        private readonly ApplicationContext _context;
        private readonly SQLiteContextTests _contextTest;
        public RepositoryClient(ApplicationContext context, SQLiteContextTests contextTest) : base(context)
        {
            _context = context;
            _contextTest = contextTest;
        }
        public virtual void AddClient(ClientDTO obj)
        {
            try
            {
                _context.Set<ClientDTO>().Add(obj);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public virtual IEnumerable<ClientDTO> GetAllClients()
        {
            return _context.Set<ClientDTO>().ToList();
        }

        //<===========Usar _contextTest apenas para testes automatizados===========>
        //public virtual IEnumerable<ClientDTO> GetAllClients()
        //{
        //var clients = _contextTest.GetDataBase();
        //if (_contextTest.Set<ClientDTO>().ToList().Count == 0)
        //{                
        //    AddDataInContext(clients);
        //}
        //else
        //{
        //    RemoveDataInContext(clients);
        //}
        //return _contextTest.Set<ClientDTO>().ToList();
        //}
        //public void AddDataInContext(List<ClientDTO> clients)
        //{
        //    _context.AddRange(clients);
        //    _context.SaveChanges();
        //}
        //public void RemoveDataInContext(List<ClientDTO> clients)
        //{
        //    _context.RemoveRange(clients);
        //    _context.SaveChanges();
        //}
    }
}
