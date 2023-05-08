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

    public class HomeController : ControllerBase
    {
        IUnitOfWork unitOfWork;


        public HomeController(IUnitOfWork _unitOfWork)
        {

            unitOfWork = _unitOfWork;


        }




        [HttpGet("artists/{userId}")]

        public ActionResult<ResultDTO> getallArtists(string userId)
        {
            //var allartists = unitOfWork.ArtistRepository.GetArtists(id, p => p.IsDeleted == false);
            ResultDTO result = new ResultDTO();
            List<Artist> artists = unitOfWork.ArtistRepository.GetAll(a => a.IsDeleted == false);

            if (artists != null)
            {
                List<string> ArtistNames = new List<string>();

                List<string> ArtistImages = new List<string>();
                int count = 6;

                for (int i = 0; i < 6; i++) /////////////////////666666666666666666666666666666666666666666666666
                {
                    ArtistNames.Add(artists[i].FirstName + " " + artists[i].LastName);
                    ArtistImages.Add(artists[i].Image);
                }

                result.IsPassed = true;
                result.Data = new { ArtistNames = ArtistNames, ArtistImages = ArtistImages };
                return result;
            }
            result.IsPassed = false;
            result.Data = "No Artist Exist With this Id";
            return result;
        }

      
        [HttpGet("recentlyplayedsong/{userId}")]
        public ActionResult<ResultDTO> GetLatestSongSorted(string userId)
        {
            ResultDTO result = new ResultDTO();
            User user = unitOfWork.UserRepository.GetByIdString(userId, u => u.IsDeleted == false);
            List<Song> songs;
            if (user != null)
            {
                songs = unitOfWork.SongRepository.GetLatestSongSortedDec(userId, s => s.IsDeleted == false);
                if (songs != null)
                {
                    result.IsPassed = true;
                    result.Data = songs;
                    return result;
                }
                result.IsPassed = false;
                result.Data = "Songs is Null";
            }
            result.IsPassed = false;
            result.Data = "No user Exist With this Id";
            return result;
        }

        [HttpGet("recentlyplaylistplayed/{userId}")]
        public ActionResult<ResultDTO> GetLatestPlayListSorted(string userId)
        {
            ResultDTO result = new ResultDTO();
            User user = unitOfWork.UserRepository.GetByIdString(userId, u => u.IsDeleted == false);
            if (user != null)
            {
                List<Playlist> playlists = unitOfWork.PlayListRepository
                    .GetLatestPlayListsSortedDec(userId, p => p.IsDeleted == false);
                if (playlists != null)
                {
                    List<ReturnPlaylistDTO> returnPlaylistDTOs = new List<ReturnPlaylistDTO>();
                    foreach (Playlist playlist in playlists)
                    {
                        returnPlaylistDTOs.Add(new ReturnPlaylistDTO { Id = playlist.Id, Name = playlist.Name, Image = playlist.Image, UserId = playlist.UserId, IsDeleted = playlist.IsDeleted });
                    }
                    result.IsPassed = true;
                    result.Data = returnPlaylistDTOs;
                    return result;
                }

                result.IsPassed = false;
                result.Data = "Playlists IS Null";
                return result;

            }
            result.IsPassed = false;
            result.Data = "No user Exist With this Id";
            return result;
        }

        // اوعي تنسي تعدل الامر هنا في الكونترولر ده + لا تنسي ان تضيف البوم انترفيسوكلاس
        [HttpGet("featuredcharts")]
        public ActionResult<ResultDTO> GetAlbumsFeaturedCharts()
        {
            ResultDTO result = new ResultDTO();
           
            List<Song> bestsongsInWorld = unitOfWork.SongRepository
                .GetMostSongListenInTheWorld(s => s.IsDeleted == false);

            // لسة في جزئيتين هرجعهم
            if (bestsongsInWorld != null)
            {

                List<ReturnSongDTO> returnSongDTOs = new List<ReturnSongDTO>();
                foreach (Song song in bestsongsInWorld)
                {
                    returnSongDTOs.Add(new ReturnSongDTO
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
            result.IsPassed = true;
            result.Data = "No Songs Exist";
            return result;
            
        }

        [HttpGet("Classic")]
        public ActionResult<ResultDTO> GetClassicSongs()
        {
            ResultDTO result = new ResultDTO();

            List<Song> cLassicSongs = unitOfWork.SongRepository
                .GetClassicSongs(s => s.IsDeleted == false);

            // لسة في جزئيتين هرجعهم
            if (cLassicSongs != null)
            {

                List<ReturnSongDTO> returnSongDTOs = new List<ReturnSongDTO>();
                foreach (Song song in cLassicSongs)
                {
                    returnSongDTOs.Add(new ReturnSongDTO
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
            result.IsPassed = true;
            result.Data = "No Songs Exist";
            return result;
        }

        [HttpGet("rab")]
        public ActionResult<ResultDTO> GetRabSongs(string userId)
        {
            ResultDTO result = new ResultDTO();
            
            List<Song> RabSongs = unitOfWork.SongRepository
                .GetRabSongs(s => s.IsDeleted == false);

            // لسة في جزئيتين هرجعهم
            if (RabSongs != null)
            {

                List<ReturnSongDTO> returnSongDTOs = new List<ReturnSongDTO>();
                foreach (Song song in RabSongs)
                {
                    returnSongDTOs.Add(new ReturnSongDTO
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
            result.IsPassed = true;
            result.Data = "No Songs Exist";
            return result;
            
        }


        [HttpGet("romantic")]
        public ActionResult<ResultDTO> GetRomanticSongs(string userId)
        {
            ResultDTO result = new ResultDTO();
            
            List<Song> romanticSongs = unitOfWork.SongRepository
                .GetRomanticSongs(s => s.IsDeleted == false);

            // لسة في جزئيتين هرجعهم
            if (romanticSongs != null)
            {

                List<ReturnSongDTO> returnSongDTOs = new List<ReturnSongDTO>();
                foreach (Song song in romanticSongs)
                {
                    returnSongDTOs.Add(new ReturnSongDTO
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
            result.IsPassed = true;
            result.Data = "No Songs Exist";
            return result;
            
        }
    }
}


            //}
            //result.IsPassed = false;
            //result.Data = "No user Exist With this Id";
            //return result;


//Recently played song
//Recently played playlist
//Featured charts
//Classic
//Romantic
//Rab            
     

//Home & Song & SongType





//    public class HomeController : ControllerBase
//    {
//        IUnitOfWork unitOfWork;


//        public HomeController(IUnitOfWork _unitOfWork)
//        {

//            unitOfWork = _unitOfWork;


//        }




//        [HttpGet("artists/{userId}")]

//        public ActionResult<ResultDTO> getallArtists(string userId)
//        {
//            //var allartists = unitOfWork.ArtistRepository.GetArtists(id, p => p.IsDeleted == false);
//            ResultDTO result=new ResultDTO();
//            List<Artist> artists = unitOfWork.ArtistRepository.GetAll(a=>a.IsDeleted==false);

//            if (artists != null)
//            {
//                List<string> ArtistNames = new List<string>();

//                List<string> ArtistImages = new List<string>();
//                int count = 6;

//                for (int i = 0; i < 6; i++) /////////////////////666666666666666666666666666666666666666666666666
//                {
//                    ArtistNames.Add(artists[i].FirstName + " " + artists[i].LastName);
//                    ArtistImages.Add(artists[i].Image);
//                }

//                result.IsPassed = true;
//                result.Data = new {ArtistNames=ArtistNames, ArtistImages=ArtistImages};
//                return result;
//            }
//            result.IsPassed = false;
//            result.Data = "No Artist Exist With this Id";
//            return result;
//        }

//        // Recently played song
//        // Recently played playlist
//        // Featured charts
//        [HttpGet("recentlyplayedsong/{userId}")]
//        public ActionResult<ResultDTO> GetLatestSongSorted(string userId)
//        {
//            ResultDTO result = new ResultDTO();

//            //List<Song> song = unitOfWork.SongRepository.
//            return result;
//        }

//    }
//}