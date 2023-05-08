using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Spotify.DTO;
using Spotify.Models;
using Spotify.Repository.Base;

namespace Spotify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public LikesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public ActionResult<ResultDTO> AddLike(AddLikeDTO likeDTO)
        {
            ResultDTO result=new ResultDTO();
            if(ModelState.IsValid)
            {
                Likes like = new Likes();
                if (likeDTO != null)
                {
                    like.UserId = likeDTO.UserId;
                    like.SongId = likeDTO.SongId;
                    like.LikeDate = likeDTO.LikeDate;

                    _unitOfWork.LikesRepository.Add(like);
                    result.IsPassed = true;

                    ReturnLikesDTO returnLikesDTO = new ReturnLikesDTO();
                    returnLikesDTO.Id = like.Id;
                    returnLikesDTO.UserId= like.UserId;
                    returnLikesDTO.SongId = like.SongId;
                    returnLikesDTO.LikeDate = like.LikeDate;
                    returnLikesDTO.IsDeleted = like.IsDeleted;

                    result.Data = returnLikesDTO;
                    return result;
                }
                result.IsPassed=false;
                result.Data = "Like is null !! ";
                return result;
            }
            result.IsPassed = false;
            result.Data = "Model State is invalid";
            return result;
        }
    }
}
