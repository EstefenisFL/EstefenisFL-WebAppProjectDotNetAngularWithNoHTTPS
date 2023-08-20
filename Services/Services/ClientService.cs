using Domain.Models;
using ProjectWebData.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Services.Services
{
    public class ClientService : ServiceBase<ClientDTO>, IClientService
    {
        public readonly IRepositoryClient _repositoryClient;
        public ClientService(IRepositoryClient repositoryClient) : base(repositoryClient)
        {
            _repositoryClient = repositoryClient;
        }

        public void AddClient(ClientDTO newClient)
        {
            _repositoryClient.AddClient(newClient);
        }
        override
        public ClientDTO GetById(int id)
        {
            return _repositoryClient.GetById(id);
        }
        public IEnumerable<ClientDTO> FindAllClients()
        {
            return _repositoryClient.GetAllClients();
        }
        override
        public void Update(ClientDTO obj)
        {
            _repositoryClient.Update(obj);
        }        
        public void RemoveClient(int id)
        {
            var client = _repositoryClient.GetById(id);
            _repositoryClient.Remove(client);
        }
        public void RemoveForTestsAUT()
        {
            _repositoryClient.RemoveClientForTestsAUT();
        }
    }
}
