using System.ComponentModel;

namespace Spotify.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<PlaylistSong>? PlaylistSongs { get; set; }
    }
}
