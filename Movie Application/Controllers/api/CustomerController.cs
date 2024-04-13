using Microsoft.AspNetCore.Mvc;
using Movie_Application.Models;

namespace Movie_Application.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return new Customer { Name = "" };
            }
            return customer;
        }
    }
}
