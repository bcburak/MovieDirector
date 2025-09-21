using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MovieDirectorApp.Application.Commands
{

    public class DeleteMovieCommand(string Id) : IRequest<bool>
    {
        [Required(ErrorMessage = "Id is required")]
        public string Id { get; set; } = string.Empty;
    }
}
