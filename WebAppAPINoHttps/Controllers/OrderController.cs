using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppAPINoHttps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger ;
        private readonly IOrderService _orderService;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        // GET: api/Order
        [HttpGet]
        public IEnumerable<OrderDTO> GetAll()
        {
            return _orderService.FindAllOrders();
        }

        // GET api/Order/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
