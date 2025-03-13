using AutoMapper;
using BusinessLogicLayer.IServices;
using DomainLayer.Model;
using DomainLayer.UserDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        IMapper _imapper;

        public UserController(IUserService userService, IMapper imapper)
        {
            _userService = userService;
            _imapper = imapper;
        }

        //endpoint to get all users
        [HttpGet]
        public IActionResult GetUsers()
        {
            // This method is synchronous
            return Ok(_imapper.Map<List<UserDto>>(_userService.GetAllUsers()));
        }

        //endpoint to get one user
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            // This method is asynchronous
            User? user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            UserDto existingUser = _imapper.Map<UserDto>(user);
            return Ok(user);
        }

        //endpoint to create user
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
        {

            // Call the service to create the user
            var createdUser = await _userService.CreateUser(userDto);

            if (createdUser == null)
            {
                return BadRequest("User creation failed."); // Return error message
            }

            // Map the created user to a DTO for the response
            var resultDto = _imapper.Map<UserDto>(createdUser);

            return Ok(resultDto); // Return the created user DTO
        }

        //endpoint to update a user
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto userdto)
        {
            User existingUser = _imapper.Map<User>(userdto);
            // Assuming this is asynchronous, but modify if it's not
            User? userUpdate = await _userService.UpdateUser(existingUser);
            if (userUpdate is null)
            {
                return BadRequest();
            }

            UserDto newUser = _imapper.Map<UserDto>(userUpdate);
            return Ok(newUser);
        }

        //endpoint to delete a user
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            // Assuming this is asynchronous, but modify if it's not
            bool isDeleted = await _userService.DeleteUser(id);
            if (!isDeleted)
            {
                return BadRequest();
            }
            return Ok(new { Message = "Deleted successfully" });
        }
    }
}