using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spotify.DTO;
using Spotify.Models;
using Spotify.Repository;
using Spotify.Repository.Base;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Spotify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly IUnitOfWork unit;
        private readonly IHostingEnvironment host;

        public SongController(IUnitOfWork _unit, IHostingEnvironment _host)
        {
            unit = _unit;
            host = _host;
        }
        [HttpPost]
        public async Task<IActionResult> AddSong([FromForm] SongModelDTO songDTO)
        {
            ResultDTO resultDTO = new ResultDTO();
            Song song = new Song();
            AlbumSongs albumSong= new AlbumSongs();
            if(ModelState.IsValid)
            {
                song.Name = songDTO.Name;
                song.ArtistId = song.ArtistId;
                // ينفع احسب وقت الاغنية من السي شارب ؟ ولو ايوة فازاي ؟؟ 
                song.Duration = songDTO.Duration;

                song.ReleaseDate= songDTO.ReleaseDate;
                song.Lyrics= songDTO.Lyrics;

                string fileName = string.Empty;
                if (songDTO.ImageFile == null || songDTO.ImageFile.Length == 0)
                {
                    resultDTO.IsPassed = false;
                    resultDTO.Data = "No File Selected";
                    return BadRequest(resultDTO);
                }

                string myUpload = Path.Combine(host.WebRootPath, "images");
                fileName = songDTO.ImageFile.FileName;
                string fullPath = Path.Combine(myUpload, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await songDTO.ImageFile.CopyToAsync(stream);
                }

                song.Image = "http://localhost:5292/images/" + fileName;

                song.ArtistId= songDTO.ArtistId;

                string audioFileName = string.Empty;
                if (songDTO.AudioFile == null || songDTO.AudioFile.Length == 0)
                {
                    resultDTO.IsPassed= false;
                    resultDTO.Data = "No AudioFile Selected";
                    return BadRequest(new { IsPassed = false, ErrorMessage = "No File Selected" });
                }

                string myAudioUpload = Path.Combine(host.WebRootPath, "audios");
                audioFileName = songDTO.AudioFile.FileName;
                string fullAudioPath = Path.Combine(myAudioUpload, audioFileName);

                using (var stream = new FileStream(fullAudioPath, FileMode.Create))
                {
                    await songDTO.AudioFile.CopyToAsync(stream);
                }
                song.Audio= "http://localhost:5292/audios/" + audioFileName;

                song.TypeId = songDTO.TypeId;

                unit.SongRepository.Add(song);
                albumSong.SongId = song.Id;
                albumSong.AlbumId = songDTO.AlbumId;
                unit.AlbumSongRepository.Add(albumSong);

                AlbumSongs oldAlbumSong = unit.AlbumSongRepository
                .GetAlbumSongByIdWithAlbum(song.Id, a=> a.IsDeleted == false);
                song.AlbumName = oldAlbumSong.Album.Name;
                song.AlbumImage=oldAlbumSong.Album.Image;

                unit.CommitChanges();
                
                resultDTO.IsPassed= true;
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

                resultDTO.Data = returnSongDTO;
                return Ok(resultDTO);
            }
            resultDTO.IsPassed= false;
            resultDTO.Data = ModelState;
            return BadRequest(resultDTO);
        }

        [HttpGet("GetSongById/{songId}")]
        public IActionResult GetSongById (int songId)
        {
            ResultDTO resultDTO = new ResultDTO();
            Song song = unit.SongRepository.GetById(songId, s => s.IsDeleted == false);
            if(song != null) 
            { 
                resultDTO.IsPassed= true;
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
                resultDTO.Data = returnSongDTO;
                return Ok(resultDTO);
            }
            resultDTO.IsPassed = false;
            resultDTO.Data = "No Song Exist With This ID";
            return Ok(resultDTO);
        }
    }
}
