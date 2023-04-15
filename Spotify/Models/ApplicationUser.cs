using Microsoft.AspNetCore.Identity;

namespace Spotify.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Gender { get; set; }
        public string Image { get; set; }
        public bool ISDeleted { get; set; }
    }
}
