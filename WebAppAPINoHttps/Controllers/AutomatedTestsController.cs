using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppAPINoHttps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutomatedTestsController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IClientService _clientService;

        public AutomatedTestsController(ILogger<ClientController> logger, IClientService clientService)
        {
            _logger = logger;
            _clientService = clientService;
        }
        // GET: api/AutomatedTests
        [HttpGet]
        public IEnumerable<ClientDTO> GetAll()
        {
            return _clientService.FindAllClients();
        }

        // GET api/AutomatedTests/5
        [HttpGet("{id}")]
        public ClientDTO Get(int id)
        {
            return _clientService.GetById(id);
        }

        // POST api/AutomatedTests
        [HttpPost]
        public void Post([FromBody] ClientDTO newClient)
        {
            var optionForTestAUT = 2;
            newClient.Option = optionForTestAUT;
            _clientService.AddClient(newClient);
        }

        // PUT api/Client/5
        [HttpPut("{registrationNumber}")]
        public void Put(string registrationNumber, [FromBody] string value)
        {
        }

        // DELETE api/AutomatedTests/5
        [HttpDelete()]
        public void Delete()
        {
            _clientService.RemoveForTestsAUT();
        }
    }
}
