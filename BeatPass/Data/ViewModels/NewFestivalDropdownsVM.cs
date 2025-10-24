using BeatPass.Models;

namespace BeatPass.Data.ViewModels
{
    public class NewFestivalDropdownsVM
    {
        public NewFestivalDropdownsVM()
        {
            Organizations = new List<Organization>();
            Locations = new List<Location>();
            Artists = new List<Artist>();
        }
        public List<Organization> Organizations { get; set; }
        public List<Location> Locations { get; set; }
        public List<Artist> Artists { get; set; }

    }
}
