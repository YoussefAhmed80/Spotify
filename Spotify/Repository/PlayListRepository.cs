using Microsoft.EntityFrameworkCore;
using Spotify.Models;
using Spotify.Repository.Base;

namespace Spotify.Repository
{
    public class PlayListRepository : Repository<Playlist>, IPlayListRepository
    {
        Context context;
        public PlayListRepository(Context _Context) : base(_Context)
        {

            context = _Context;
        }

        public List<Playlist> GetPlaylists(string userid, Func<Playlist, bool> predicate)
        {

            var allPlaylits = context.Playlists.Include(l => l.User)
                .Where(l => l.UserId == userid)
                .Where(predicate).ToList();

            return allPlaylits;
        }

        public List<Playlist> GetLatestPlayListsSortedDec(string userId, Func<Playlist, bool> predicate)
        {
            List<ListenDate> listenDates = context.ListenDates.Include(ld => ld.Song)
                .Where(ld => ld.UserId == userId).ToList();
            
            List<int> LatestSongsId = new List<int>();
            foreach (ListenDate item in listenDates)
            {
                LatestSongsId.Add(item.Song.Id);
            }
            
            List<int> LatestPlayListsId = new List<int>();
            foreach (int songId in LatestSongsId)
            {
                LatestPlayListsId.Add(context.PlaylistsSong
                .Where(ps => ps.IsDeleted == false)
                .Where(ps => ps.SongId == songId)
                .Select(ps => ps.PlaylistId)
                .FirstOrDefault());
            }

            List<Playlist> Playlists = new List<Playlist>();
            foreach (int pId in LatestPlayListsId)
            {
                Playlists
                    .Add(context.Playlists
                    .Where(p => p.IsDeleted == false)
                    .Where(p => p.Id == pId)
                    .FirstOrDefault());
            }
            
            return Playlists;
        }
    }
}
