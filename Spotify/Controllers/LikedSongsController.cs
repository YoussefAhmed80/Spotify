using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spotify.DTO;
using Spotify.Models;
using Spotify.Repository;
using Spotify.Repository.Base;

namespace Spotify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikedSongsController : ControllerBase
    {
        IUnitOfWork unitOfWork;

        public LikedSongsController(IUnitOfWork _unitOfWork)
        {

            unitOfWork = _unitOfWork;
        }

        [HttpGet("{userId}")]
        public IActionResult GetAllSongsByUesrId(string userId)
        {
            List<Likes> listoflikes = unitOfWork.LikedSongsRepository.GetAllSongsByUesrId(userId);
            List<LikedSongDTO> LikedSongsDTO = new List<LikedSongDTO>();
            foreach (var s in listoflikes)
            {
                LikedSongDTO songsDTO = new LikedSongDTO();
                songsDTO.SongName = s.Song.Name;
                songsDTO.ArtistName = s.User.FirstName;
                songsDTO.AlbumName = s.Song.AlbumName;
                songsDTO.Image = s.Song.AlbumImage;
                songsDTO.AddingDate = s.LikeDate;
                
                LikedSongsDTO.Add(songsDTO);
            }
            ResultDTO result = new ResultDTO();
            
            result.IsPassed = true;
            result.Data= LikedSongsDTO;
            return Ok(result);
        }
    }
}
