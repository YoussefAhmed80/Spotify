
using System.ComponentModel;

namespace Spotify.DTO
{
    public class ReturnSongDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Duration { get; set; }
        public string Audio { get; set; }
        public string Image { get; set; }
        public string? AlbumName { get; set; }
        public string? AlbumImage { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Lyrics { get; set; }
        public int ListenTimes { get; set; }
        public bool IsDeleted { get; set; }
        public int TypeId { get; set; }
        public string ArtistId { get; set; }
    }
}
