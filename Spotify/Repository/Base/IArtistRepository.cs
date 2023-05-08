using Spotify.Models;

namespace Spotify.Repository.Base
{
    public interface IArtistRepository : IRepository<Artist>
    {
        List<Artist> GetArtists(string id, Func<Artist, bool> predicate);
    }
}
