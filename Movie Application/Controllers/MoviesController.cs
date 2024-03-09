using Microsoft.AspNetCore.Mvc;
using Movie_Application.Models;
using Movie_Application.ViewModel;

namespace Movie_Application.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            var moviesList = new List<Movie>()
            {
                new Movie() {Id = 1, Name ="John Wick 1"},
                new Movie() {Id = 1, Name ="John Wick 2"},
                new Movie() {Id = 1, Name ="John Wick 3"},
                new Movie() {Id = 1, Name ="John Wick 4"}
            };

            var moviesViewModel = new MoviesViewModel()
            {
                MoviesList = moviesList
            };
            return View(moviesViewModel);
        }

        // Movies/Random
        public IActionResult Random()
        {
            var movie = new Movie() { Id = 1, Name = "Jhon Wick 4"};
            var customerList = new List<Customer>()
            {
                new Customer() { Id = 1, Name = "Sunku Saarthak"},
                new Customer() { Id = 2, Name = "Tharun" },
                new Customer() { Id = 3, Name = "Pavan"}
            };

            var viewModel = new RandomViewModel()
            {
                movie = movie,
                customers = customerList
            };
            return (View(viewModel));
        }
    }
}
