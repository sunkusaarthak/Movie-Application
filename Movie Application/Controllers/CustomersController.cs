using Microsoft.AspNetCore.Mvc;
using Movie_Application.Models;
using Movie_Application.ViewModel;

namespace Movie_Application.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {
            List<Customer> customerList = new List<Customer>()
            {
                new Customer() {Id = 1, Name = "Sunku Saarthak"},
                new Customer() {Id = 2, Name = "Tharun"},
                new Customer() {Id = 3, Name = "Pavan"}
            };

            var customers = new CustomersViewModel()
            {
                Customers = customerList
            };

            return View(customers);
        }
    }
}
