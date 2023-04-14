using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spotify.Models
{
    public class PlaylistSong
    {
        public int Id { get; set; }
        public int Rank { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        
        public int SongId { get; set; }
        [ForeignKey("SongId")]
        public virtual Song Song { get; set; }
        public int PlaylistId { get; set; }
        [ForeignKey("PlaylistId")]
        public virtual Playlist Playlist { get; set; }
        public virtual Album Album { get; set; }
    }
}
