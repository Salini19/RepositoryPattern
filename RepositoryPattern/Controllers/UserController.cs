using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Middlewares;
using RepositoryPattern.Models;
using RepositoryPattern.Repository;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;
        public UsersController(IRepository<User> userRepository)
        { 
            _userRepository = userRepository; 
        }

        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return users != null ? Ok(users) : NoContent();
        }


        [HttpGet]
        [Route("[Action]/{userId}")]
        public IActionResult GetUserById(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                throw new NotFoundException("User Not Found");
            }
          
        }


        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> CreateUser(User user)
        {
            bool isCreated = await _userRepository.AddAsync(user);
            return Ok(isCreated ? "User Created Sucessfully." : "User Creation Failed.");
        }

        [HttpDelete]
        [Route("[Action]/{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            bool isDeleted = await _userRepository.DeleteAsync(user);
            return Ok(isDeleted ? "User Deleted Sucessfully." : "User Deletion Failed.");
        }
    }
}
