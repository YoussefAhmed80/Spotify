using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spotify.DTO;
using Spotify.Repository.Base;

namespace Spotify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public TypeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            ResultDTO result = new ResultDTO();
            List<Spotify.Models.Type> types = unitOfWork.TypeRepository.GetAll(t => t.IsDeleted == false);
            if(types != null)
            {
                List<string> typesName = new List<string>();
                foreach(var type in types)
                {
                    typesName.Add(type.Name);
                }
                result.IsPassed = true;
                result.Data= typesName;
                return Ok(result);
            }
            result.IsPassed= false;
            result.Data = "No Types In database";
            return BadRequest(result);
        }
    }
}
