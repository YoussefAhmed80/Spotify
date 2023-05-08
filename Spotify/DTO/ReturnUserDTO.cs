using System.ComponentModel;

namespace Spotify.DTO
{
    public class ReturnUserDTO
    {
        public string ApplicationUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Image { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        //public string Role { get; set; }
        public bool IsDeleted { get; set; }
    }
}
