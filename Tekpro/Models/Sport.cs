using System.ComponentModel.DataAnnotations;

namespace Tekpro.Models

{
    public class Sport
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int MinuteOfGame { get; set; } = 0;
        [Required]
        public Boolean TeamSport { get; set; } = false;

        public Boolean IsSinglePlayer { get; set; } = false;

        public string Description { get; set; } = string.Empty;
        public ICollection<Club> Clubs { get; set; } = new List<Club>();
    }
}
