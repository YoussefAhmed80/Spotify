using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spotify.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Duration { get; set; }
        public string Path { get; set; }
        public DateTime ReleaseDate  { get; set; }
        public int ListenTimes { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public int ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        public virtual Artist? Artist { get; set; }
        public virtual Album? Album { get; set;}
        public virtual List<PlaylistSong>? PlaylistSongs { get; set; }
        public virtual List<SongType>? SongTypes { get; set; }
        public virtual List<Likes>? Likes { get; set;}
    }
}
