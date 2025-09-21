using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MovieDirectorApp.Application.Commands
{
    public class UpdateMovieCommand : IRequest<bool>
    {

        //Assuming that Id value could be already obtained
        [Required(ErrorMessage = "Id is required")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(200, ErrorMessage = "Title cannot be longer than 200 characters")]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "Description is required")]
        [MaxLength(200, ErrorMessage = "Title cannot be longer than 200 characters")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Release date is required")]
        public DateTime ReleaseDate { get; set; }
        [Range(1900, 2100, ErrorMessage = "Year must be between 1900 and 2100")]
        public int Year { get; set; }
        public int Rating { get; set; }

        [Required(ErrorMessage = "ImdbId is required")]
        public double ImdbId { get; set; }
        public string DirectorId { get; set; } = string.Empty;
    }

}
