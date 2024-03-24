using Microsoft.AspNetCore.Mvc;
using Movie_Application.Models;
using Movie_Application.ViewModel;
using System.Data.Entity;

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

        public IActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == Id);
            return View(movie);
        }

        // Movies/Random
        /*public IActionResult Random()
        {
            var movie = new Movie() { Id = 1, Name = "Jhon Wick 4" };
            var customerList = new List<Customer>();
            var viewModel = new RandomViewModel()
            {
                movie = movie,
                customers = customerList
            };
            return (View(viewModel));
        }*/

        private IEnumerable<Movie> GetMovies()
        {
            var moviesList = _context.Movies.Include(m => m.Genre).ToList();
            return moviesList;
        }
    }
}
