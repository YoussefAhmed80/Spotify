using Microsoft.EntityFrameworkCore;

namespace Spotify.Models
{
    public class Context:DbContext
    {
        public Context() { }
        public Context(DbContextOptions options):base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Likes> Likes { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<PlaylistSong> PlaylistsSong { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<ArtType> ArtTypes { get; set; }
        public DbSet<SongType> SongsTypes { get; set; }
    }
}
