using AutoMapper;
using BusinessLogicLayer.IServices;
using BusinessLogicLayer.Service;
using DomainLayer.CommentDto;
using DomainLayer.DTO;
using DomainLayer.LikeDto;
using DomainLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        ILikeService _likeService;
        IMapper _imapper;

        public LikeController(ILikeService likeService, IMapper imapper)
        {
            _likeService = likeService;
            _imapper = imapper;
        }


        //endpoint to get all likes
        [HttpGet]
        public IActionResult GetLike()
        {
            
            return Ok(_imapper.Map<List<LikeDto>>(_likeService.GetAllLike()));

        }

        //endpoint to create like
        [HttpPost]
        public IActionResult CreateLike([FromBody] CreateLikeDto likedto)
        {
            Like newLike = _imapper.Map<Like>(likedto);
 
            Like? creaeLike = _likeService.CreateLike(newLike, out string message);

            if (creaeLike == null)
            {
                return BadRequest(message);
            }

            LikeDto existingLike = _imapper.Map<LikeDto>(creaeLike);

            return Ok(existingLike);
        }

        //endpoint to delete a like
        [HttpDelete("{id}")]
        public IActionResult DeleteLike(int id) // Add the parameter type (int)
        {
            // Call the service to delete the like
            bool isDeleted = _likeService.DeleteLike(id, out string message);

            // If deletion fails, return a BadRequest with the error message
            if (!isDeleted)
            {
                return BadRequest(message);
            }

            // Return a success response with the message
            return Ok(new { Message = message });
        }
    }
}
