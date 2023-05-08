using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spotify.Models
{
    public class ListenDate
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int SongId { get; set; }
        [ForeignKey("SongId")]
        public Song Song { get; set; }
        
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
