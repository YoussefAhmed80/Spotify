using System.ComponentModel;

namespace Spotify.DTO
{
    public class ReturnLikesDTO
    {
        public int Id { get; set; }
        public DateTime LikeDate { get; set; }
        public bool IsDeleted { get; set; }
        public string UserId { get; set; }
        public int SongId { get; set; }
    }
}
