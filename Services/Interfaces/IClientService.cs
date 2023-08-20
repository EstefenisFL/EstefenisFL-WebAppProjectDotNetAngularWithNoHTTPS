using Domain.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface IClientService
    {
        void AddClient(ClientDTO obj);

        ClientDTO GetById(int id);

        IEnumerable<ClientDTO> FindAllClients();

        void Update(ClientDTO obj);

        void Remove(ClientDTO obj);

        void RemoveForTestsAUT();

        void Dispose();
    }
    
}
