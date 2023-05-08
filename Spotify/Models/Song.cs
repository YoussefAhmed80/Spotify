using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spotify.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Duration { get; set; }
        public string Audio { get; set; }
        public string Image { get; set; }
        public string? AlbumName { get; set; }
        public string? AlbumImage { get; set; }
        public DateTime ReleaseDate  { get; set; }
        public string Lyrics { get; set; }
        [DefaultValue(0)]
        public int ListenTimes { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public virtual Type? Type { get; set; }

        public string ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        public virtual Artist? Artist { get; set; }
        
        public virtual List<PlaylistSong>? PlaylistSongs { get; set; }
        
        public virtual List<Likes>? Likes { get; set;}
        
        public virtual List<ListenDate>? ListenDates { get; set; }

        public virtual AlbumSongs? AlbumSongs { get; set;}
    }
}

        //public virtual List<SongType>? SongTypes { get; set; }