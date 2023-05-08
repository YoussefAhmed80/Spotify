using Spotify.Models;

namespace Spotify.Repository.Base
{
    public interface IAlbumSongRepository : IRepository<AlbumSongs>
    {
        AlbumSongs GetAlbumSongByIdWithAlbum(int id,Func<AlbumSongs,bool> predicate);
    }
}
