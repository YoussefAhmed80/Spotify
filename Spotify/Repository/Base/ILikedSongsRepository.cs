using Spotify.Models;

namespace Spotify.Repository.Base
{
    public interface ILikedSongsRepository : IRepository<Likes>
    {
        List<Likes> GetAllSongsByUesrId(string userId);
    }
}
