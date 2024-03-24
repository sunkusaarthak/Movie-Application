using Microsoft.AspNetCore.Mvc;
using Movie_Application.Models;
using Movie_Application.ViewModel;

namespace Movie_Application.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context;

        public MoviesController()
        {
            _context = ApplicationDbContext.Create();
        }
        public IActionResult Index()
        {
            var moviesViewModel = new MoviesViewModel()
            {
                MoviesList = GetMovies()
            };
            return View(moviesViewModel);
        }

        // Movies/Random
        public IActionResult Random()
        {
            var movie = new Movie() { Id = 1, Name = "Jhon Wick 4" };
            var customerList = new List<Customer>()
            /*{
                new Customer() { Id = 1, Name = "Sunku Saarthak"},
                new Customer() { Id = 2, Name = "Tharun" },
                new Customer() { Id = 3, Name = "Pavan"}
            }*/;

            var viewModel = new RandomViewModel()
            {
                movie = movie,
                customers = customerList
            };
            return (View(viewModel));
        }

        private IEnumerable<Movie> GetMovies()
        {
            var moviesList = _context.Movies.OrderBy(m => m.Id).ToList();

            return moviesList;
        }
    }
}
