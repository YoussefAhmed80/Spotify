using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spotify.Models
{
    public class ArtType
    {
        public int Id { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public int ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        public virtual Artist? Artist { get; set; }
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public virtual Type? Type { get; set; }
    }
}
