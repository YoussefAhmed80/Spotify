using Spotify.Models;

namespace Spotify.Repository.Base
{
    public interface IFollowerRepository : IRepository<Follower>
    {
        int FollowersCount(string ArtistID);
    }
}
