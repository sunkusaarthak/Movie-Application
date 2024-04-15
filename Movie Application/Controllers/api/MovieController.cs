using Microsoft.AspNetCore.Mvc;
using Movie_Application.Models;
using Movie_Application.ViewModel;

namespace Movie_Application.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _context.Movies.SingleOrDefault(x => x.Id == id);
        }

        public IActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var movieFormViewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    GenreList = _context.Genres.ToList()
                };
                //return View("MovieForm", movieFormViewModel);
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
    }
}
