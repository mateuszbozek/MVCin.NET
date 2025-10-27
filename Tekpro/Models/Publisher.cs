using System.ComponentModel.DataAnnotations;

namespace Tekpro.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
