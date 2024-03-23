using Movie_Application.Models;

namespace Movie_Application.ViewModel
{
    public class MoviesViewModel
    {
        public required IEnumerable<Movie> MoviesList { get; set; }
    }
}
