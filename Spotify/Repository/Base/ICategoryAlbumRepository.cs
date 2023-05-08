using Spotify.Models;

namespace Spotify.Repository.Base
{
    public interface ICategoryAlbumRepository : IRepository<Album>
    {
        List<Album> GetCategoryAlbums(int id, Func<Category, bool> predicate);
    }
    
}
