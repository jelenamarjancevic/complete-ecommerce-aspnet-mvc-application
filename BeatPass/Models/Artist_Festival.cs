namespace BeatPass.Models
{
    public class Artist_Festival
    {
        public int FestivalId { get; set; }
        public Festival Festival { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        

    }
}
