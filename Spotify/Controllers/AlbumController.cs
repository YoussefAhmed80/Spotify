using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Spotify.DTO;
using Spotify.Models;
using Spotify.Repository;
using Spotify.Repository.Base;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Spotify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        IUnitOfWork unitOfWork;
        private readonly IHostingEnvironment host;

        public AlbumController(IUnitOfWork _unitOfWork, IHostingEnvironment _host)
        {

            unitOfWork = _unitOfWork;
            host = _host;
        }
        
        [HttpPost]
        public async Task<IActionResult> AddAlbum([FromForm] AddingAlbumDTO albumDTO)
        {
            ResultDTO result=new ResultDTO();
            Album album = new Album();
            if(ModelState.IsValid)
            {
                album.Name= albumDTO.Name;
                album.ReleaseDate= albumDTO.ReleaseDate;
                album.ArtistId = albumDTO.ArtistId;
                album.CategoryId= albumDTO.CategoryId;
                string fileName = string.Empty;
                if (albumDTO.File == null || albumDTO.File.Length == 0)
                {
                    result.IsPassed = false;
                    result.Data = "No File Selected";
                    return BadRequest(result);
                }

                string myUpload = Path.Combine(host.WebRootPath, "images");
                fileName = albumDTO.File.FileName;
                string fullPath = Path.Combine(myUpload, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await albumDTO.File.CopyToAsync(stream);
                }
                album.Image = "http://localhost:5292/images/" + fileName;
                unitOfWork.AlbumRepository.Add(album);

                ////////////////////////////////////////////////////////
                ///
                ReturnAlbumDTO returnAlbumDTO = new ReturnAlbumDTO();

                returnAlbumDTO.ArtistId = album.ArtistId;
                returnAlbumDTO.Id = album.Id;
                returnAlbumDTO.Image = album.Image;
                returnAlbumDTO.IsDeleted = album.IsDeleted;
                returnAlbumDTO.Name = album.Name;
                returnAlbumDTO.ReleaseDate = albumDTO.ReleaseDate;
                
                result.IsPassed = true;
                result.Data = returnAlbumDTO;
                return Ok(result);
            }
            result.IsPassed = false;
            result.Data = "ModelState Is Invalid";
            return BadRequest(result);
        }
    }
}
