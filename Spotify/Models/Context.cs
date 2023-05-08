using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Spotify.Models
{
    public class Context: IdentityDbContext<ApplicationUser>
    {
        public Context() { }
        public Context(DbContextOptions options):base(options) { }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Likes> Likes { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<PlaylistSong> PlaylistsSong { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ListenDate> ListenDates { get; set; }
        //public DbSet<AlbumCategory> AlbumCategory { get; set; }
        public DbSet<AlbumSongs> AlbumSongs { get; set; }
    }
}
