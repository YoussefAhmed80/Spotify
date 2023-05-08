using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using Spotify.DTO;
using Spotify.Models;
using Spotify.Repository.Base;

namespace Spotify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryAlbumSongsController : ControllerBase
    {
        IUnitOfWork unitOfWork;


        public CategoryAlbumSongsController(IUnitOfWork _unitOfWork)
        {

            unitOfWork = _unitOfWork;


        }

        [HttpGet("CategoryAlbumsongs{name}")]
        public ActionResult<ResultDTO> getCategoryAlbumsongs(string name)
        {

            ResultDTO result = new ResultDTO();
            var CategoryAlbumsongs = unitOfWork.CategoryAlbumSongsRepository
                .GetCategoryAlbumSongs(name, l => l.IsDeleted == false);


            List<CategoryAlbumSongDTO> categoryAlbumSongDTO = new List<CategoryAlbumSongDTO>();
            foreach (var song in CategoryAlbumsongs)
            {
                CategoryAlbumSongDTO newCategoryAlbumSongDTO = new CategoryAlbumSongDTO
                {
                 SongImage = song.Image,
                 SongName = song.Name,

                };
                categoryAlbumSongDTO.Add(newCategoryAlbumSongDTO);
            }
            result.IsPassed= true;
            result.Data= categoryAlbumSongDTO;
            return result;

        }
    }
}
