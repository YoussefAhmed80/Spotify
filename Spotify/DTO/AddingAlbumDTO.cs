namespace Spotify.DTO
{
    public class AddingAlbumDTO
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public IFormFile File { get; set; }
        public string ArtistId { get; set; }
        public int CategoryId { get; set; }
    }
}
