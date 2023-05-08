using Spotify.Models;

namespace Spotify.Repository.Base
{
    public interface ISongsRepository : IRepository<Song>
    {
        List<Song> GetSongsWithAlbumsandArtist(Func<Song, bool> predicate);
        List<Song> GetLatestSongSortedDec(string userId, Func<Song, bool> predicate);
        public List<Song> GetClassicSongs(Func<Song, bool> predicate);
        public List<Song> GetRabSongs(Func<Song, bool> predicate);
        public List<Song> GetRomanticSongs(Func<Song, bool> predicate);
        public List<Song> GetMostSongListenInTheWorld(Func<Song, bool> predicate);
        public Song GetFirstSongRealeazed(string artistId, Func<Song, bool> predicate);
    }
}
