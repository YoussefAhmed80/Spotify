using Microsoft.EntityFrameworkCore;
using Spotify.Models;
using Spotify.Repository.Base;

namespace Spotify.Repository
{
    public class LikedSongsRepository:Repository<Likes>,ILikedSongsRepository
    {
         Context Context;
        public LikedSongsRepository(Context _Context) : base(_Context)
        {
            Context = _Context;
        }

        public List<Likes> GetAllSongsByUesrId(string userId)
        {
           

            List<Likes> likedsongs= Context.Likes.Include(U=>U.User)
                .Include(S=>S.Song).Include(s=>s.Song.Artist)
                .Where(L=>L.UserId== userId).ToList();
            return likedsongs;

        }
    }
}
