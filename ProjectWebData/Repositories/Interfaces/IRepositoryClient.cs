using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWebData.Repositories.Interfaces
{
    public interface IRepositoryClient : IRepositoryBase<ClientDTO>
    {
        IEnumerable<ClientDTO> GetAllClients();
        void AddClient(ClientDTO newClient);
    }
}
