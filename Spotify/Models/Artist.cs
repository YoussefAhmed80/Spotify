using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Spotify.Models
{
    public class Artist
    {
        [Key]
        public string ApplicationUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string? Image { get; set; }
        public string Bio { get; set; }
        //public string Role { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser? ApplicationUser { get; set; }
        public virtual List<Album>? Albums { get; set; }
        
        public virtual List<Song>? Songs { get; set; }
        public virtual List<Follower>? Follower { get; set; }
    }
}
