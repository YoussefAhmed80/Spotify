using Spotify.Models;
using Spotify.Repository.Base;

namespace Spotify.Repository
{
    
    public class FollowerRepository : Repository<Follower>,IFollowerRepository
    {
        Context _context;
        public FollowerRepository (Context context) : base(context)
        {
            _context = context;
        }
        public int FollowersCount(string ArtistID)
        {
            int count = _context.Followers.Where(f=>f.ArtistId==ArtistID).Count();
            return count;
        }
    }
}
