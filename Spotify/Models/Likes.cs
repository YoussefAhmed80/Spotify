using Microsoft.Extensions.Configuration.UserSecrets;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spotify.Models
{
    public class Likes
    {
        public int Id { get; set; }
        public DateTime LikeDate { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int SongId { get; set; }
        [ForeignKey("SongId")]
        public virtual Song Song { get; set; }
    }
}
