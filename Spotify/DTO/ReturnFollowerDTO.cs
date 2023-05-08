using System.ComponentModel;

namespace Spotify.DTO
{
    public class ReturnFollowerDTO
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string UserId { get; set; }
        public string ArtistId { get; set; }
    }
}
