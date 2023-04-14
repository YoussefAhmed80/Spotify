using Spotify.Models;
using Spotify.Repository.Base;

namespace Spotify.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public Context Context;
        public UnitOfWork(Context _Context) 
        {
            Context = _Context;
            Songs = new Repository<Song>(Context);
            
        }
        public IRepository<Song> Songs { get; set; }

        public int CommitChanges()
        {
            return Context.SaveChanges();
        }
    }
}
