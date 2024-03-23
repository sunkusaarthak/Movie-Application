using Microsoft.AspNetCore.Mvc;
using Movie_Application.Models;
using Movie_Application.ViewModel;

namespace Movie_Application.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {
            var customers = new CustomersViewModel() 
            { 
                Customers = GetCustomers()
            };
            return View(customers);
        }

        public IActionResult Details(int id)
        {
            var customer = GetCustomers().FirstOrDefault(p => p.Id == id);
            if(customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>()
            {
                new Customer() {Id = 1, Name = "Sunku Saarthak"},
                new Customer() {Id = 2, Name = "Tharun"},
                new Customer() {Id = 3, Name = "Pavan"}
            };
        }
    }
}
