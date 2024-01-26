using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppAPINoHttps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;
        private readonly IItemService _itemService;

        public ItemController(ILogger<ItemController> logger, IItemService itemService)
        {
            _logger = logger;
            _itemService = itemService;
        }
        // GET: api/Item
        [HttpGet]
        public IEnumerable<ItemDTO> GetAll()
        {
            return _itemService.FindAllItens();
        }

        // GET api/Item/5
        [HttpGet("{id}")]
        public ItemDTO Get(int id)
        {
            return _itemService.GetById(id);
        }

        // POST api/Item
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/Item/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Item/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
