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

        [ValidateAntiForgeryToken]
        public IActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var movieFormViewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    GenreList = _context.Genres.ToList()
                };
                return View("MovieForm", movieFormViewModel);
            }
            if (movie.Id == 0)
            {
                movie.DateInserted = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.FirstOrDefault(m => m.Id == movie.Id);
                if (movieInDb != null)
                {
                    movieInDb.Name = movie.Name;
                    movieInDb.GenreId = movie.GenreId;
                    movieInDb.Stock = movie.Stock;
                    movieInDb.ReleaseDate = movie.ReleaseDate;
                }
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public IActionResult MovieForm(int Id)
        {
            Movie movie = _context.Movies.FirstOrDefault(m => m.Id == Id);
            if (movie == null)
            {
                movie = new Movie { Name = "" };
            }
            MovieFormViewModel movieFormViewModel = new MovieFormViewModel
            {
                Movie = movie,
                GenreList = _context.Genres.ToList()
            };
            return View(movieFormViewModel);
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
