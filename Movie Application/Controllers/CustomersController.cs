using Microsoft.AspNetCore.Mvc;
using Movie_Application.Models;
using Movie_Application.ViewModel;
using System.Data.Entity;

namespace Movie_Application.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = ApplicationDbContext.Create();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult EditCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            CustomerFormViewModel viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var dbCustomer = _context.Customers.Single(c => c.Id == customer.Id);
                dbCustomer.Name = customer.Name;
                dbCustomer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                dbCustomer.MembershipTypeId = customer.MembershipTypeId;
                dbCustomer.DateOfBirth = customer.DateOfBirth;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public IActionResult CustomerForm()
        {
            CustomerFormViewModel newCustomerViewModel = new CustomerFormViewModel()
            {
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View(newCustomerViewModel);
        }
        public IActionResult Index()
        {
            /*_context.Customers.Add(new Customer()
            {
                Name = "Test",
                IsSubscribedToNewsletter = true,
                MembershipTypeId = 1
            });*/
            var customers = new CustomersViewModel()
            {
                Customers = _context.Customers.Include(c => c.MembershipType).ToList()
            };
            return View(customers);
        }

        public IActionResult Details(int id)
        {
            var customer = _context.Customers.Include(m => m.MembershipType).FirstOrDefault(p => p.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
    }
}
