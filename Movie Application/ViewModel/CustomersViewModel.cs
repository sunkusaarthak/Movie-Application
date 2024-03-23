using Movie_Application.Models;

namespace Movie_Application.ViewModel
{
    public class CustomersViewModel
    {
        public required IEnumerable<Customer> Customers { get; set; }
    }
}
