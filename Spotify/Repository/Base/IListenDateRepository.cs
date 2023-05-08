using Spotify.Models;

namespace Spotify.Repository.Base
{
    public interface IListenDateRepository : IRepository<ListenDate>
    {
        List<Song> GetLatestSongsSorted(string userId);
    }
}
