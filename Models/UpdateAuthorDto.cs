using System.ComponentModel.DataAnnotations;

namespace AuthorsAndBooksAPI.Models
{
    public class UpdateAuthorDto
    {
        [Required(ErrorMessage = "Firstname is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lastname is required")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public string Age { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
