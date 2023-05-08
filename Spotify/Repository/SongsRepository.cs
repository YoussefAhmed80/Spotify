using Microsoft.EntityFrameworkCore;
using Spotify.Models;
using Spotify.Repository.Base;

namespace Spotify.Repository
{
    public class SongsRepository : Repository<Song>, ISongsRepository
    {
        Context context;
        public SongsRepository(Context _Context) : base(_Context)
        {

            context = _Context;
        }
        public List<Song> GetSongsWithAlbumsandArtist(Func<Song, bool> predicate)
        {
            List<Song> SongsbyAlbumsandArtist = context.Songs.Include(l => l.Artist)
            .Where(predicate).ToList();
            return SongsbyAlbumsandArtist;
        }
        public List<Song> GetLatestSongSortedDec(string userId, Func<Song, bool> predicate)
        {
            List<ListenDate> listenDates = context.ListenDates.Include(ld => ld.Song)
                .Where(ld => ld.UserId == userId).OrderByDescending(l=>l.Date).ToList();

            List<Song> LatestSongs = new List<Song>();
            foreach (ListenDate item in listenDates)
            {
                LatestSongs.Add(item.Song);
            }

            return LatestSongs.Where(predicate).ToList();
        }

        public Song GetFirstSongRealeazed(string artistId, Func<Song, bool> predicate)
        {
            Song song = context.Songs.Include(s => s.Artist)
                .Where(s => s.ArtistId == artistId)
                .Where(predicate)
                .OrderBy(s=>s.ReleaseDate).FirstOrDefault();
            
            return song;
        }

            //List<Song> LatestSongs = new List<Song>();
            //foreach (ListenDate item in listenDates)
            //{
            //    LatestSongs.Add(item.Song);
            //}
            //LatestSongs.Where(predicate).ToList()

        public List<Song> GetClassicSongs(Func<Song, bool> predicate)
        {
            List<Song> songs = context.Songs.Include(s=>s.Type)
                .Where(s=>s.Type.Name=="Classic").ToList();
            return songs;
        }

        public List<Song> GetRabSongs(Func<Song, bool> predicate)
        {
            List<Song> songs = context.Songs.Include(s => s.Type)
                .Where(s => s.Type.Name == "Rab").ToList();
            return songs;
        }

        public List<Song> GetRomanticSongs(Func<Song, bool> predicate)
        {
            List<Song> songs = context.Songs.Include(s => s.Type)
                .Where(s => s.Type.Name == "Romantic").ToList();
            return songs;
        }

        public List<Song> GetMostSongListenInTheWorld(Func<Song, bool> predicate)
        {
            List<Song> songs = context.Songs.Where(s => s.ListenTimes > 0)
                .Where(predicate).OrderBy(s => s.ListenTimes).ToList();
            return songs;
        }

        public Song GetSongById(int songId)
        {
            Song song = context.Songs.Where(s=>s.Id==songId).FirstOrDefault();
            return song;
        }
    }
}