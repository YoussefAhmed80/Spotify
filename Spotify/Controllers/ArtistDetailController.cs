using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spotify.DTO;
using Spotify.Models;
using Spotify.Repository.Base;

namespace Spotify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistDetailController : ControllerBase
    {
        IUnitOfWork unitOfWork;


        public ArtistDetailController(IUnitOfWork _unitOfWork)
        {

            unitOfWork = _unitOfWork;


        }
        [HttpGet("getallsongbyartist/{artistId}")]

        public ActionResult<ResultDTO> getallsongbyartist(string artistId)
        {
            ResultDTO result = new ResultDTO();

            List<string> songs = new List<string>();
            List<string> Artists = new List<string>();
            List<string> Albums = new List<string>();


            var songbyartist = unitOfWork.ArtistDetailsRepository
                .GetSongforArtist(l => l.IsDeleted == false && l.ArtistId == artistId ).ToList();

            List<ArtistDetailsDTO> artistDetailsDTO = new List<ArtistDetailsDTO>();
            foreach (var songData in songbyartist)
            {
                ArtistDetailsDTO newartistDetailsDTO = new ArtistDetailsDTO
                {
                    ListenTimesSong = songData.ListenTimes,
                    ArtistName = songData.Artist.FirstName + songData.Artist.LastName,
                    SongName = songData.Name,

                    SongImage = songData.Image,
                    SongDuration = songData.Duration,
                    ArtistImage = songData.Artist.Image,

                };
                artistDetailsDTO.Add(newartistDetailsDTO);
            }

            result.IsPassed= true;
            result.Data= artistDetailsDTO;
            return result;
        }

        [HttpGet("getFirstsonginartistprofile/{artistId}")]
        public IActionResult PlayFirstSongInProfile(string artistId)
        {
            ResultDTO result = new ResultDTO();
            Song song = unitOfWork.SongRepository.GetFirstSongRealeazed(artistId,s=>s.IsDeleted==false);
            if(song != null)
            {
                result.IsPassed = true;
                ReturnSongDTO returnSongDTO = new ReturnSongDTO()
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
                };
                result.Data= returnSongDTO;
                return Ok(result);

            }
            result.IsPassed= false;
            result.Data = "This Artist Page Has not Added ";
            return BadRequest(result);
        }
    }
}
