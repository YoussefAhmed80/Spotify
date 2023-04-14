using System.ComponentModel;

namespace Spotify.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Image { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        
        public virtual Likes? Likes { get; set; }
        public virtual List<Playlist>? Playlist { get; set; }
        public virtual List<Follower>? Followers { get; set; }
    }
}
