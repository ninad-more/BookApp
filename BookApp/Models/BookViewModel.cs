using System.ComponentModel.DataAnnotations;

namespace BookApp.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Book Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Book Cost")]
        public decimal Price { get; set; }

        public int Pages { get; set; }

        [Display(Name = "Book Category")]
        public BookType Type { get; set; }

        [Display(Name = "Is Cheap")]
        public bool IsCheap { get; set; }
    }

    public enum BookType
    {
        SchoolBook,
        StoryBook,
        PoetryBook,
        NoteBook
    }
}
