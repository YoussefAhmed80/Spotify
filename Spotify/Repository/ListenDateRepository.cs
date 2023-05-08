using Microsoft.EntityFrameworkCore;
using Spotify.Models;
using Spotify.Repository.Base;

namespace Spotify.Repository
{
    public class ListenDateRepository : Repository<ListenDate>, IListenDateRepository
    {
        Context _context;
        public ListenDateRepository(Context context):base(context) 
        {
            _context = context;
        }

        public List<Song> GetLatestSongsSorted(string userId)
        {
            List<ListenDate> listenDates=_context.ListenDates.Include(ld=>ld.Song)
            .Where(ld=>ld.UserId == userId).ToList();
            List<Song> LatestSongs= new List<Song>();
            foreach(ListenDate item in listenDates)
            {
                LatestSongs.Add(item.Song);
            }
            return LatestSongs;
        }
    }
}
