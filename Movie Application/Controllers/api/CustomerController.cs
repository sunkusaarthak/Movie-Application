using Microsoft.AspNetCore.Mvc;
using Movie_Application.Models;
using System.Web.Http;

namespace Movie_Application.Controllers.api
{
    [System.Web.Http.Route("api/[controller]")]
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
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }
            return customer;
        }

        [System.Web.Http.HttpPost]
        public Customer PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
            }

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        public void UpdateCustomer(int Id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
            }
            var CurrentCustomer = _context.Customers.FirstOrDefault(c => c.Id == Id);
            if (CurrentCustomer == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
            }
            CurrentCustomer.Name = customer.Name;
            CurrentCustomer.MembershipType = customer.MembershipType;
            CurrentCustomer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            CurrentCustomer.MembershipTypeId = customer.MembershipTypeId;
            _context.SaveChanges();
        }

        [System.Web.Http.HttpDelete]
        public void DeleteCustomer(int Id)
        {
            var CurrentCustomer = _context.Customers.FirstOrDefault(c => c.Id == Id);
            if (CurrentCustomer == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
            }
            _context.Customers.Remove(CurrentCustomer);
            _context.SaveChanges();
        }
    }
}
