using Spotify.Models;
using Spotify.Repository.Base;

namespace Spotify.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser> , IApplicationUserRepository
    {
        Context context;
        public ApplicationUserRepository(Context context):base(context) 
        {
            this.context = context;
        }
        public ApplicationUser GetByUserName(string userName) 
        {
            ApplicationUser user = context.ApplicationUsers
                .Where(a=>a.UserName == userName).FirstOrDefault();
            
            return user;
        }

        //string GetUserRoleForThisApplicationUser(string applicationUserId)
        //{
        //    ApplicationUser applicationUser=context.I
        //}

    }
}
