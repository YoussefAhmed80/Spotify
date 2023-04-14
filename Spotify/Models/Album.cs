using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spotify.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Image { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public int ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        public virtual Artist Artist { get; set; }
        public virtual List<Song> Songs { get; set; }
    }
}
