using Microsoft.Extensions.Configuration.UserSecrets;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Spotify.Models
{
    public class Likes
    {
        public int Id { get; set; }
        public DateTime LikeDate { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
        public int SongId { get; set; }
        [ForeignKey("SongId")]
        public virtual Song? Song { get; set; }
    }
}
