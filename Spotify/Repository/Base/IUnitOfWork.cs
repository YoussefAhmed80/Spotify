using Spotify.Models;

namespace Spotify.Repository.Base
{
    public interface IUnitOfWork
    {
        IRepository<Song> Songs { get; set; }
        int CommitChanges();
    }
}
