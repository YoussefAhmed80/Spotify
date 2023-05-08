using Microsoft.AspNetCore.Identity;
using Spotify.Models;

namespace Spotify.Repository.Base
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        ApplicationUser GetByUserName(string userName);
        //string GetUserRoleForThisApplicationUser(string applicationUserId);
    }
}
