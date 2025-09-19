namespace MovieDirectorApp.Domain.Entities
{
    public class Movie
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; } = string.Empty;
        public int Year { get; set; }
        public string DirectorId { get; set; } = string.Empty;
    }
}
