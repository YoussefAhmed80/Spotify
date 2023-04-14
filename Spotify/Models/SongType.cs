using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spotify.Models
{
    public class SongType
    {
        public int Id { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public int SongId { get; set; }
        [ForeignKey("SongId")]
        public virtual Song? Song { get; set; }
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public virtual Type? Type { get; set; }
    }
}
