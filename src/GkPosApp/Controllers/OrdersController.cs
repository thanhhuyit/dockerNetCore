using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GkPosApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {        
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(ILogger<OrdersController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetOrders")]
        public IEnumerable<OrderViewModel> Get(string shopId)
        {
            return Enumerable.Range(1, 5).Select(index => new OrderViewModel
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                OrderNumber = $"Order-of-{shopId}-id-{index}",
                Total  = 1000 + index
            })
            .ToArray();
        }
    }
}