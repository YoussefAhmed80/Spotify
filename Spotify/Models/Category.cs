using System.ComponentModel;

namespace Spotify.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public virtual List<Album>? Albums { get; set; }


    }
}
