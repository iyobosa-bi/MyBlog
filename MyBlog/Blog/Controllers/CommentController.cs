using AutoMapper;
using BusinessLogicLayer.IServices;
using BusinessLogicLayer.Service;
using DomainLayer.CommentDto;
using DomainLayer.Model;
using DomainLayer.UserDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        ICommentService _icommentService;
        IMapper _imapper;

        public CommentController(ICommentService icommentService, IMapper imapper)
        {
            _icommentService = icommentService;
            _imapper = imapper;
        }


        //endpoint to get all comments
        [HttpGet]
        public IActionResult GetPost()
        {
            return Ok(_imapper.Map<List<CommentDto>>(_icommentService.GetAllComments()));
        }


        //endpoint to get one comment
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Comment? comment = _icommentService.GetComment(id);

            if (comment == null)
            {
                return NotFound();
            }

            CommentDto newComment = _imapper.Map<CommentDto>(comment);

            return Ok(newComment);
        }


        //endpoint to create comment
        [HttpPost]
        public IActionResult CreatePost([FromBody] CommentDto commentdto)
        {
            Comment newComment = _imapper.Map<Comment>(commentdto);

            Comment? createComment = _icommentService.CreateComment(newComment, out string message);

            if (createComment == null)
            {
                return BadRequest(message);
            }

            CommentDto latestcomment = _imapper.Map<CommentDto>(createComment);

            return Ok(latestcomment);
        }

        //endpoint to update a post
        [HttpPut]
        public IActionResult UpdatePost([FromBody] UpdateCommentDto commentdto)
        {
            Comment existingComment = _imapper.Map<Comment>(commentdto);

            Comment? commentUpdate = _icommentService.UpdateComment(existingComment, out string message);

            if (commentUpdate is null)
            {
                return BadRequest(message);
            }

            CommentDto latestcomment = _imapper.Map<CommentDto>(commentUpdate);

            return Ok(latestcomment);
        }
    }
}
