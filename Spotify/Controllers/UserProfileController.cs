using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Spotify.DTO;
using Spotify.Models;
using Spotify.Repository.Base;

namespace Spotify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUnitOfWork unit;
        public UserProfileController(IUnitOfWork _unit) 
        { 
            unit=_unit;
        }

        [HttpGet("user/{userId}")]
        public ActionResult<ResultDTO> GetUserNameAndImage(string userId)
        {
            ResultDTO result = new ResultDTO();
            User user = unit.UserRepository.GetByIdString(userId, u => u.IsDeleted == false);
            if(user != null)
            {
                result.IsPassed = true;
                UserNameAndImageDTO userNameAndImageDTO = new UserNameAndImageDTO();
                userNameAndImageDTO.Name = user.FirstName + " " + user.LastName;
                userNameAndImageDTO.Image = user.Image;
                result.Data = userNameAndImageDTO;
                return result;
            }
            result.IsPassed = false;
            result.Data = "No User Exist With this ID";
            return result;
        }

        [HttpGet("Latest10song/{userId}")]
        public ActionResult<ResultDTO> GetLatestSong(string userId)
        {
            ResultDTO result = new ResultDTO();
            User user = unit.UserRepository.GetByIdString(userId, u => u.IsDeleted == false);
            if (user != null)
            {
                List<Song> songs = unit.ListenDateRepository.GetLatestSongsSorted(userId);
                
                List<ReturnSongDTO> returnSongDTOs = new List<ReturnSongDTO>();
                foreach (Song song in songs)
                {
                    returnSongDTOs.Add(new ReturnSongDTO()
                    {
                        Id = song.Id,
                        Name = song.Name,
                        ArtistId = song.ArtistId,
                        ReleaseDate = song.ReleaseDate,
                        AlbumImage = song.AlbumImage,
                        AlbumName = song.AlbumName,
                        Audio = song.Audio,
                        Duration = song.Duration,
                        Image = song.Image,
                        IsDeleted = song.IsDeleted,
                        ListenTimes = song.ListenTimes,
                        Lyrics = song.Lyrics,
                        TypeId = song.TypeId
                    });
                }

                result.IsPassed = true;
                result.Data = returnSongDTOs;
                return result;
            }
            result.IsPassed=false;
            result.Data= "No User Exist With this ID";
            return result;
        }
    }
}