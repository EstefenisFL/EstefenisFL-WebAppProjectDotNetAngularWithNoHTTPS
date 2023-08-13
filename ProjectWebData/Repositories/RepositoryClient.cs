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
        public RepositoryClient(ApplicationContext context) : base(context)
        {
               _context = context;
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

        public virtual ClientDTO GetById(int id)
        {
            return _context.Set<ClientDTO>().Find(id);
        }

        public virtual IEnumerable<ClientDTO> GetAllClients()
        {
            return _context.Set<ClientDTO>().ToList();
        }

        public virtual void Update(ClientDTO obj)
        {

            try
            {
                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public virtual void Remove(ClientDTO obj)
        {
            try
            {
                _context.Set<ClientDTO>().Remove(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void Dispose()
        {
            _context.Dispose();
        }
    }
}
