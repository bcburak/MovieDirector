using System.ComponentModel.DataAnnotations;

namespace MovieDirectorApp.Domain.Entities
{
    public class Director : BaseEntity
    {
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "SecondName is required")]
        public string SecondName { get; set; } = string.Empty;
        [Required(ErrorMessage = "BirthDate date is required")]
        public DateTime BirthDate { get; set; }
        public string Bio { get; private set; } = string.Empty;

    }


}
