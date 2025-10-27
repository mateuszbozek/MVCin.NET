using System.ComponentModel.DataAnnotations;

namespace Tekpro.Models
{
    public class Player
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surename { get; set; }

        public Club Club { get; set; }
        public int ClubId { get; set; }

    }
}
