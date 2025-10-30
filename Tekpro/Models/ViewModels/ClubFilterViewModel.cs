namespace Tekpro.Models.ViewModels
{
    public class ClubFilterViewModel
    {
        public string? ClubName { get; set; }
        public string? SportName { get; set; }

        public string? PlayerSurename { get; set; }

        public List<Club>? Clubs { get; set; }
    }
}
