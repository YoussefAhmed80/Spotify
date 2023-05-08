using Microsoft.AspNetCore.Identity;

namespace Spotify.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string? Image { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public bool IsDeleted { get; set; }
    }
}
