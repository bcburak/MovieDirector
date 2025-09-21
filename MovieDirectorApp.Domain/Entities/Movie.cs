namespace MovieDirectorApp.Domain.Entities
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public int Year { get; set; }
        public int Rating { get; set; }
        public double ImdbId { get; set; }
        public string DirectorId { get; set; } = string.Empty;
    }
}
