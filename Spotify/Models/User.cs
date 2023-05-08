using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Spotify.Models
{
    public class User
    {
        [Key]
        public string ApplicationUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Image { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        //public string Role { get; set; }


        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser? ApplicationUser { get; set; }
        public virtual List<Likes>? Likes { get; set; }
        public virtual List<Playlist>? Playlist { get; set; }
        public virtual List<Follower>? Followers { get; set; }
        public virtual List<ListenDate>? ListenDates { get; set; }
    }
}
