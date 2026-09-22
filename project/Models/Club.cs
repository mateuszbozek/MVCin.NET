using Tekpro.Controllers;

namespace Tekpro.Models
{
    public class Club
    {

        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int SportId { get; set; }

        public Sport Sport { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}
