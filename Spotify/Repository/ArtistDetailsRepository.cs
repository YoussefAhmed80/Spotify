using Microsoft.EntityFrameworkCore;
using Spotify.Models;
using Spotify.Repository.Base;

namespace Spotify.Repository
{
    public class ArtistDetailsRepository : Repository<Song>, IArtistDetailsRepository
    {
        Context context;
        public ArtistDetailsRepository(Context _Context) : base(_Context)
        {

            context = _Context;
        }
        public List<Song> GetSongforArtist(Func<Song, bool> predicate)
        {
            var SongsbyAlbumsandArtist = context.Songs.Include(l => l.Artist)


             .Where(predicate).ToList();

            return SongsbyAlbumsandArtist;
        }
    }
}
