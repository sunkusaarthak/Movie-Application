using Movie_Application.Models;

namespace Movie_Application.ViewModel
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> GenreList { get; set; }
        public Movie Movie { get; set; }
    }
}