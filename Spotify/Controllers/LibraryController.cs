using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spotify.DTO;
using Spotify.Models;
using Spotify.Repository;
using Spotify.Repository.Base;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Spotify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {


        IUnitOfWork unitOfWork;
        

        public LibraryController(IUnitOfWork _unitOfWork )
        {

            unitOfWork = _unitOfWork;
            

        }

        [HttpGet("allLikes{id}")]
        public IActionResult getallLikes( string id) 
        {
            ResultDTO result = new ResultDTO();

            var LikedSongs = unitOfWork.LikesRepository.GetLikesbysongsandartist( id,l=>l.IsDeleted==false); 
            List<string> songs = new List<string>();
            List<string> Artists = new List<string>();
            string username = LikedSongs[0].User.FirstName + " " + LikedSongs[0].User.LastName;
            foreach (var l in LikedSongs)
            {
                songs.Add(l.Song.Name);
                Artists.Add(l.Song.Artist.FirstName+" "+l.Song.Artist.LastName);
            }
            LikesDTO likesDTO = new LikesDTO();
            likesDTO.SongNames= songs;
            likesDTO.AtristNames = Artists;

            result.IsPassed = true;
            result.Data = likesDTO;
            return Ok(result);
        }

        [HttpGet("allPlayLists/{id}")]
        public IActionResult getallPlayLists( string id)
        {
            ResultDTO result = new ResultDTO();
            var allPlaylits = unitOfWork.PlayListRepository.GetPlaylists(id,p => p.IsDeleted == false);
            string username = allPlaylits[0].User.FirstName + " " + allPlaylits[0].User.LastName;
            
            List<ReturnPlaylistDTO> returnPlaylistDTO = new List<ReturnPlaylistDTO>();

            foreach(var l in allPlaylits)
            {
                returnPlaylistDTO.Add(new ReturnPlaylistDTO 
                { Id=l.Id, Name=l.Name,Image=l.Image , UserId=l.UserId
                , IsDeleted = l.IsDeleted});
            }
            result.IsPassed=true;
            result.Data = returnPlaylistDTO;
            return Ok(result);
        }
    }
}
