using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Spotify.Models
{
    public class User
    {
        [Key]
        public string ApplicationUserId { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Likes? Likes { get; set; }
        public virtual List<Playlist>? Playlist { get; set; }
        public virtual List<Follower>? Followers { get; set; }
    }
}
