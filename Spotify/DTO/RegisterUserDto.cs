using System.ComponentModel.DataAnnotations;

namespace Spotify.DTO
{
    public class RegisterUserDto
    {
        [Required]
        public string UserName { get; set; }

        public string Password { get; set; }



        public string Email { get; set; }

    }
}
