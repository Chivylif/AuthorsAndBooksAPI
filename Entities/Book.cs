using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorsAndBooksAPI.Entities
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(300)]
        public string? Description { get; set; }

        [Required]
        public string ProductionYear { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        public int AuthorId { get; set; }

    }
}
