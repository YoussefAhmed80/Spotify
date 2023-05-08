using Microsoft.EntityFrameworkCore;
using Spotify.Models;
using Spotify.Repository.Base;

namespace Spotify.Repository
{
    public class CategoryAlbumRepository : Repository<Album>, ICategoryAlbumRepository
    {
        Context context;
        public CategoryAlbumRepository(Context _Context) : base(_Context)
        {

            context = _Context;
        }

        public List<Album> GetCategoryAlbums(int categoryId, Func<Category, bool> predicate)
        {

            //List<List<AlbumCategory>> albumCategories = context.Albums.Include(a => a.AlbumCategory).ThenInclude(ac => ac.Category).Select(a => a.AlbumCategory).ToList();
            //List<AlbumCategory> albumCategories = AllAlbums.Select(a => a.AlbumCategory).ToList();
            Category category = context.Categories
                .Include(c => c.Albums).Where(predicate).Where(c => c.Id == categoryId).FirstOrDefault();

            List<Album> AllAlbums = category.Albums;

            return AllAlbums;
        }
    }
    
}
