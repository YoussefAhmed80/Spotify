namespace Spotify.DTO
{
    public class SongModelDTO
    {
        public string Name { get; set; }
        public float Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Lyrics { get; set; }
        public IFormFile ImageFile { get; set; }
        public IFormFile AudioFile { get; set; }
        public int TypeId { get; set; }
        public int AlbumId { get; set; }
        public string ArtistId { get; set; }
    }
}