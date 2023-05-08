using Spotify.Models;

namespace Spotify.Repository.Base
{
    public interface ILikesrepository: IRepository<Likes>
    {
        List<Likes> GetLikesbysongsandartist( string id, Func<Likes, bool> predicate);

    }
}
