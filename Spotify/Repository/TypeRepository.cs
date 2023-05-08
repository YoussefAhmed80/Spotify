using Spotify.Models;
using Spotify.Repository.Base;

namespace Spotify.Repository
{
    public class TypeRepository : Repository<Spotify.Models.Type>, ITypeRepository
    {
        private readonly Context context;
        public TypeRepository(Context context):base(context)
        {
            this.context = context;
        }
        public int GetTypIdByName(string name)
        {
            int type = context.Types.Where(t=>t.Name == name).Select(t=>t.Id).FirstOrDefault();
            return type;
        }
    }
}
