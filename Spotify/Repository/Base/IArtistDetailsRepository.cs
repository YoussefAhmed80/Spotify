using Spotify.Models;

namespace Spotify.Repository.Base
{
    public interface IArtistDetailsRepository : IRepository<Song>
    {
        List<Song> GetSongforArtist(Func<Song, bool> predicate);
    }
    
}
