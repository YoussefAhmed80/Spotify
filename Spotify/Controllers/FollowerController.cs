using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spotify.DTO;
using Spotify.Models;
using Spotify.Repository.Base;

namespace Spotify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowerController : ControllerBase
    {
        private readonly IUnitOfWork unit;
        public FollowerController (IUnitOfWork _unit)
        {
            unit = _unit;
        }

        [HttpGet]
        public ActionResult<ResultDTO> GetFollowersCountForthisArtist(string artistId)
        {
            ResultDTO result =new ResultDTO();
            Artist artist = unit.ArtistRepository.GetByIdString(artistId,a=>a.IsDeleted==false);
            
            if (artist != null)
            {
                result.IsPassed = true;
                int FollowersCount = unit.FollowerRepository.FollowersCount(artistId);
                result.Data = FollowersCount;
                return result;
            }
            result.IsPassed = false;
            result.Data= "No Artist Exist With this Id";
            return result;
        }

        [HttpPost]
        public ActionResult<ResultDTO> AddFollower(AddFollowerDTO followerDTO)
        {
            ResultDTO result=new ResultDTO();
            if(ModelState.IsValid)
            {
                Follower follower = new Follower();
                if(followerDTO != null)
                {
                    follower.UserId = followerDTO.UserId;
                    follower.ArtistId = followerDTO.ArtistId;
                    unit.FollowerRepository.Add(follower);

                    ReturnFollowerDTO returnFollowerDTO = new ReturnFollowerDTO();
                    returnFollowerDTO.ArtistId = follower.ArtistId;
                    returnFollowerDTO.UserId = follower.UserId;
                    returnFollowerDTO.Id=follower.Id;
                    returnFollowerDTO.IsDeleted = follower.IsDeleted;

                    result.IsPassed = true;
                    result.Data = returnFollowerDTO;
                    return result;
                }
                result.IsPassed = false;
                result.Data = "No Follower Sended";
                return result;
            }
            result.IsPassed = false;
            result.Data = "Validations Not Validate";
            return result;
        }
    }
}
