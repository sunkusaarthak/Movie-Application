using System.Data.Entity;

namespace Movie_Application.Models
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext() { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<MembershipType> MembershipTypes { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}
