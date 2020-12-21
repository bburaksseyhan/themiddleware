using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CustomerApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MonitorApi.Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            var customers = new List<Customer>();
            customers.Add(new Customer()
            {
                Id = 1,
                FirsName = "Burak",
                LastName = "Seyhan",
                City = "Ankara",
                EmailAddress = "burakseyhan8@gmail.com",
                Fax = string.Empty,
                Phone = "444"
            });
            customers.Add(new Customer()
            {
                Id = 2,
                FirsName = "User_FirstName",
                LastName = "User_LastName",
                City = "User_City",
                EmailAddress = "user@gmail.com",
                Fax = string.Empty,
                Phone = "User_PhoneNumber"
            });

            return customers;
        }
    }
}
