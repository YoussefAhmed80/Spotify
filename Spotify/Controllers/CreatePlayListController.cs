using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Spotify.DTO;
using Spotify.Models;
using Spotify.Repository.Base;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;


namespace Spotify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreatePlayListController : ControllerBase
    {
        IUnitOfWork unitOfWork;
        private readonly IHostingEnvironment host;


        public CreatePlayListController(IUnitOfWork _unitOfWork, IHostingEnvironment _host)
        {
            unitOfWork = _unitOfWork;
            host = _host;
        }
        [HttpGet("getallsongbyartist")]

        public IActionResult getallsongbyartist()
        {
            List<string> songs = new List<string>();
            List<string> Artists = new List<string>();
            List<string> Albums = new List<string>();


            var songbyartist = unitOfWork.SongRepository.GetSongsWithAlbumsandArtist(l => l.IsDeleted == false).ToList();

            List<SongDTO> songsDto = new List<SongDTO>();
            foreach (var songData in songbyartist)
            {
                SongDTO song = new SongDTO
                {
                    AlbumsNames = songData.AlbumName,
                    AtristNames = songData.Artist.FirstName,
                    SongNames = songData.Name,
                    image = songData.Image,
                };
                songsDto.Add(song);
            }


            return Ok(songsDto);
        }
        [HttpPost("playlissong")]
        public IActionResult AddSongInPlayListSong(PlayListSongDTO playListSongDTO)
        {
            ResultDTO resultDTO = new ResultDTO();
            PlaylistSong ps = new PlaylistSong();
            ps.PlaylistId = playListSongDTO.PlayListId;
            ps.SongId = playListSongDTO.SongId;
            ps.Rank= playListSongDTO.Rank;
            unitOfWork.PlayListSongRepository.Add(ps);

            resultDTO.IsPassed = true;
            resultDTO.Data = playListSongDTO;
            return Ok(resultDTO);
        }

        [HttpPost("playlist")]
        public async Task<ActionResult<ResultDTO>> AddPlayList([FromForm]PlayListModelDTO playListDTO)
        {
            ResultDTO result = new ResultDTO();
            Playlist playlist = new Playlist();
            if(ModelState.IsValid)
            {
                playlist.Name = playListDTO.Name;
                playlist.UserId = playListDTO.UserID;

                string fileName = string.Empty;
                if (playListDTO.File == null || playListDTO.File.Length == 0)
                {
                    result.IsPassed= false;
                    result.Data = "No File Selected";
                    return result;
                }

                string myUpload = Path.Combine(host.WebRootPath, "images");
                fileName = playListDTO.File.FileName;
                string fullPath = Path.Combine(myUpload, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await playListDTO.File.CopyToAsync(stream);
                }

                playlist.Image = "http://localhost:5292/images/" + fileName;

                unitOfWork.PlayListRepository.Add(playlist);

                ReturnPlaylistDTO returnPlaylistDTO = new ReturnPlaylistDTO();

                returnPlaylistDTO.Id= playlist.Id;
                returnPlaylistDTO.Name= playListDTO.Name;
                returnPlaylistDTO.Image =playlist.Image;
                returnPlaylistDTO.UserId = playListDTO.UserID;
                returnPlaylistDTO.IsDeleted=playlist.IsDeleted;
                

                result.IsPassed = true;
                result.Data = returnPlaylistDTO;
                return result;
            }
            result.IsPassed = false;
            result.Data= "ModelState Is Invalid";
            return result;


        }
    }
}
