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
                if (obj.Option == 2)
                {
                    var countInMemoryDataBase = GetAllClients();
                    if (countInMemoryDataBase.Count() < 3)
                    {
                        AddClientForTestsAUT(obj);
                    }
                }
                else
                {
                    _context.Set<ClientDTO>().Add(obj);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual IEnumerable<ClientDTO> GetAllClients()
        {
            var countInMemoryDataBase = _contextTest.Set<ClientDTO>().ToList();
            if (countInMemoryDataBase.Count() == 0)
            {
                return _context.Set<ClientDTO>().ToList();
            }
            else
            {
                return countInMemoryDataBase;
            }
        }

        //<===========Usar _contextTest apenas para testes automatizados===========>
        public void AddClientForTestsAUT(ClientDTO client)
        {
            ClientDTO newClientEntity = new ClientDTO();
            newClientEntity.Name = client.Name;
            newClientEntity.RegistrationNumber = client.RegistrationNumber;
            newClientEntity.PhoneNumber = client.PhoneNumber;
            newClientEntity.CEP = client.CEP;
            newClientEntity.State = client.State;
            newClientEntity.City = client.City;

            _contextTest.Add(newClientEntity);
            _contextTest.SaveChanges();
        }
        public void RemoveClientForTestsAUT(int id)
        {
            var listOfClients = _contextTest.Set<ClientDTO>().ToList();
            if (listOfClients.Count() != 0)
            {
                foreach (ClientDTO client in listOfClients)
                {
                    if (client.Id == id)
                    {
                        _contextTest.Remove(client);
                        _contextTest.SaveChanges();
                    }
                }

            }
        }
        public void UpdateForTestAUT(ClientDTO obj)
        {
            _contextTest.Update(obj);
            _contextTest.SaveChanges();
        }
    }
}
