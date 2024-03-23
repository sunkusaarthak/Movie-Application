using Movie_Application.Models;

namespace Movie_Application.ViewModel
{
    public class RandomViewModel
    {
        public required Movie movie { get; set; }
        public required List<Customer> customers { get; set; }
    }
}
