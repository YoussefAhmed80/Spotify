using Spotify.Models;
using Spotify.Repository.Base;

namespace Spotify.Repository
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        private readonly Context context;
        public AlbumRepository(Context _Context) : base(_Context)
        {
            this.context = _Context;
        }
    }
}
