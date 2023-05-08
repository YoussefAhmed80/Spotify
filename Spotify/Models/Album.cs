using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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



        public string ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        public virtual Artist? Artist { get; set; }
        
        public virtual List<AlbumSongs>? AlbumSongs { get; set; }
        //public virtual List<AlbumCategory>? AlbumCategory { get; set; }
        public virtual int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }

    }
}

        //public int AlbumCategoryId { get; set; }
        //[ForeignKey("AlbumCategoryId")]