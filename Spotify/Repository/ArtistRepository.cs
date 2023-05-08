using Microsoft.EntityFrameworkCore;
using Spotify.Models;
using Spotify.Repository.Base;
using System.Linq;

namespace Spotify.Repository
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        Context context;
        public ArtistRepository(Context _Context) : base(_Context)
        {

            context = _Context;
        }


        public List<Artist> GetArtists(string id, Func<Artist, bool> predicate)
        {
            var Arists = context.Artists.Include(a=>a.ApplicationUser).Where(s => s.ApplicationUser.Id == id)
              .Where(predicate)
              .ToList();

            return Arists;
        }
    }
}
