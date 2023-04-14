using System.ComponentModel;

namespace Spotify.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Bio { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public virtual List<ArtType>? ArtTypes { get; set; }
        public virtual List<Album>? Albums { get; set; }
        public virtual List<Song>? Songs { get; set; }
        public virtual List<Follower>? Follower { get; set; }
    }
}
