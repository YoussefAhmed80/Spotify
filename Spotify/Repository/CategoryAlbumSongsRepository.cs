using Microsoft.EntityFrameworkCore;
using Spotify.Models;
using Spotify.Repository.Base;

namespace Spotify.Repository
{
    public class CategoryAlbumSongsRepository : Repository<Song> , ICategoryAlbumSongsRepository
    {
        Context context;
        public CategoryAlbumSongsRepository(Context _Context) : base(_Context)
        {

            context = _Context;
        }

        public List<Song> GetCategoryAlbumSongs(string name, Func<Song, bool> predicate)
        {

            var AllAlbumsongs = context.Songs.Include(s=>s.AlbumSongs).Include(s => s.AlbumSongs.Album)
                .Where(l => l.AlbumName == name)
                .Where(predicate).ToList();

            return AllAlbumsongs;
        }
    }
   
}
