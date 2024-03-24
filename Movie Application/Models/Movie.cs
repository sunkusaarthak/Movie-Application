﻿namespace Movie_Application.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateInserted { get; set; }
        public int Stock { get; set; }
    }
}
