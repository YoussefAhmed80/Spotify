namespace Spotify.DTO
{
    public class ReturnAlbumDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Image { get; set; }
        public string ArtistId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
