using System.ComponentModel;

namespace Spotify.Models
{
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public List<Song>? Songs { get; set; }

    }
}