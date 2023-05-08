namespace Spotify.DTO
{
    public class AddLikeDTO
    {
        public string UserId { get; set; }
        public int SongId { get; set; }
        public DateTime LikeDate { get; set; }
    }
}
