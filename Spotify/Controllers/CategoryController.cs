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
    public class CategoryController : ControllerBase
    {

        IUnitOfWork unitOfWork;

        public CategoryController(IUnitOfWork _unitOfWork)
        {

            unitOfWork = _unitOfWork;
        }

        [HttpGet("allCategories")]
        public ActionResult<ResultDTO> getallCategories()
        {

            ResultDTO result= new ResultDTO();
            List<Category> categories = unitOfWork.CategoryRepository

                .GetAll(l => l.IsDeleted == false);

            List<ReturnCategoryDTO> returnCategoryDTOs = new List<ReturnCategoryDTO>();

            foreach(Category cat in categories)
            {
                returnCategoryDTOs.Add(new ReturnCategoryDTO 
                { Id=cat.Id , Image= cat.Image,Name=cat.Name, IsDeleted=cat.IsDeleted});
            }
            result.IsPassed = true;
            result.Data = returnCategoryDTOs;
            return result;
        }
    }
}
