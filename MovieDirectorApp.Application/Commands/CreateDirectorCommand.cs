using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MovieDirectorApp.Application.Commands
{
    public class CreateDirectorCommand : IRequest<string>
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "SecondName is required")]
        public string? SecondName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

    }
}
