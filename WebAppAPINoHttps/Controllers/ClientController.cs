﻿using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppAPINoHttps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IClientService _clientService;

        public ClientController(ILogger<ClientController> logger, IClientService clientService)
        {
            _logger = logger;
            _clientService = clientService;
        }
        // GET: api/Client
        [HttpGet]
        public IEnumerable<ClientDTO> GetAll()
        {
            return _clientService.FindAllClients();
        }

        // GET api/Client/5
        [HttpGet("{id}")]
        public ClientDTO Get(int id)
        {
            return _clientService.GetById(id);
        }

        // POST api/Client
        [HttpPost]
        public void Post([FromBody] ClientDTO newClient)
        {
            _clientService.AddClient(newClient);
        }

        // PUT api/Client/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Client/5
        [HttpDelete("{id}")]
        public void DeleteClient(int id)
        {
            _clientService.RemoveClient(id);
        }
    }
}
