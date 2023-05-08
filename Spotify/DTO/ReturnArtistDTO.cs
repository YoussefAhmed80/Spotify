using System.ComponentModel;

namespace Spotify.DTO
{
    public class ReturnArtistDTO
    {
        public string ApplicationUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string? Image { get; set; }
        public string Bio { get; set; }
        //public string Role { get; set; }

        public bool IsDeleted { get; set; }
    }
}
