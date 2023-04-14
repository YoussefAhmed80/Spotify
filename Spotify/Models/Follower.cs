using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spotify.Models
{

    public class Follower
    {
        public int Id { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
        //[Key]
        public int ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        public virtual Artist? Artist { get; set; }
    }
}