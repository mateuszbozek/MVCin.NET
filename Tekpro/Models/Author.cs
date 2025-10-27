using System.ComponentModel.DataAnnotations;

namespace Tekpro.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surename { get; set; }

        //public Book? Book { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
