using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spotify.DTO;
using Spotify.Repository.Base;

namespace Spotify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryAlbumController : ControllerBase
    {

        IUnitOfWork unitOfWork;


        public CategoryAlbumController(IUnitOfWork _unitOfWork)
        {

            unitOfWork = _unitOfWork;


        }

        [HttpGet("CategoryAlbums{id}")]
        public ActionResult<ResultDTO> getCategoryAlbums(int id)
        {

            ResultDTO result=new ResultDTO();

            var CategoryAlbums = unitOfWork.CategoryAlbumRepository.GetCategoryAlbums(id, l => l.IsDeleted == false);


            List<AlbumDTO> albumDTO = new List<AlbumDTO>();
            foreach (var album in CategoryAlbums)
            {
                AlbumDTO newalbumDTO = new AlbumDTO
                {
                    AlbumImage = album.Image,
                    AlbumName = album.Name,
                };
                albumDTO.Add(newalbumDTO);
            }
            result.IsPassed = true;
            result.Data = albumDTO;
            return result;
        }
    }
}