using Microsoft.AspNetCore.Mvc;
using Movie_Application.Models;

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
    }
}
