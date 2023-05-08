using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spotify.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string UserId { get; set; }
        public virtual User? User { get; set; }
        public virtual List<PlaylistSong>? PlaylistSongs { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
        //public int CategoryId { get; set; }
        //[ForeignKey("CategoryId")]
        //public virtual Category? Category { get; set; }
