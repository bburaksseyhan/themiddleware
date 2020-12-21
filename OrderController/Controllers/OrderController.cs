using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OrderController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            var orders = new List<Order>();

            orders.Add(new Order()
            {
                Id = 342234,
                Name = "IPhone 11",
                IsInStock = true
            });

            orders.Add(new Order()
            {
                Id = 6564445,
                Name = "IPhone 11 Pro",
                IsInStock = false
            });

            return orders;
        }
    }
}
