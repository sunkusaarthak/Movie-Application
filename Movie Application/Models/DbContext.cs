using System.Data.Entity;

namespace Movie_Application.Models
{
    public class MyDbContext : DbContext
    {
        public required DbSet<Movie> Movies { get; set; }
        public required DbSet<Customer> Customers { get; set; }

    }
}
