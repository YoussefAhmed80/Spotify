using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spotify.Models
{
    public class Artist
    {
        [Key]
        public string ApplicationUserId { get; set; }
        public string Bio { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual List<ArtType>? ArtTypes { get; set; }
        public virtual List<Album>? Albums { get; set; }
        public virtual List<Song>? Songs { get; set; }
        public virtual List<Follower>? Follower { get; set; }
    }
}
