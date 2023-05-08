using Spotify.Models;

namespace Spotify.Repository.Base
{
    public interface ICategoryAlbumSongsRepository :IRepository<Song>
    {
        List<Song> GetCategoryAlbumSongs(string name, Func<Song, bool> predicate);
    }

}
