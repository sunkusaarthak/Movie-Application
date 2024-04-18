namespace Movie_Application.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int GenreId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateInserted { get; set; }
        public int Stock { get; set; }
    }
}
