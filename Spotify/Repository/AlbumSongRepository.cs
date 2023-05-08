using Microsoft.EntityFrameworkCore;
using Spotify.Models;
using Spotify.Repository.Base;

namespace Spotify.Repository
{
    public class AlbumSongRepository : Repository<AlbumSongs> ,IAlbumSongRepository 
    {
        Context context;
        public AlbumSongRepository(Context context):base(context)
        {
            this.context = context;
        }
        public AlbumSongs GetAlbumSongByIdWithAlbum(int id, Func<AlbumSongs, bool> predicate)
        {
            return context.AlbumSongs.Include(a=>a.Album).Where(predicate).FirstOrDefault(a=>a.SongId==id);
        }
    }
}
