using Spotify.Models;

namespace Spotify.Repository.Base
{
    public interface IPlayListRepository : IRepository<Playlist>
    {
        List<Playlist> GetPlaylists(string id, Func<Playlist, bool> predicate);
        List<Playlist> GetLatestPlayListsSortedDec(string userId, Func<Playlist, bool> predicate);
    }
}
