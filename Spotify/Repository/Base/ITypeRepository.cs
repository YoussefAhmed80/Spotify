using Spotify.Models;
namespace Spotify.Repository.Base
{
    public interface ITypeRepository : IRepository<Spotify.Models.Type>
    {
        int GetTypIdByName(string name);
    }
}
