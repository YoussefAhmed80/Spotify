using Microsoft.EntityFrameworkCore;
using Spotify.Models;
using Spotify.Repository.Base;

namespace Spotify.Repository
{
    public class LikesRepository : Repository<Likes>, ILikesrepository
    {
        Context context;
        public LikesRepository(Context _Context) : base(_Context)
        {

            context= _Context;
        }

        public List<Likes> GetLikesbysongsandartist(string userid , Func<Likes, bool> predicate)
        {

            var LikedSongs = context.Likes.Include (l=>l.User)
                .Include(s => s.Song)
                .ThenInclude(s => s.Artist)
                .Where(s => s.UserId == userid)
                .Where(predicate)
                .ToList();

            return LikedSongs;
        }
    }
}
