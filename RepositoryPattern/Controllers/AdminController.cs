using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Models;
using RepositoryPattern.Repository;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IRepository<Admin> _userRepository;
        public AdminController(IRepository<Admin> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetAllAdmins()
        {
            var admins = await _userRepository.GetAllAsync();
            if (admins != null)
            {
                return Ok(admins);
            }
            return NoContent();
        }


        [HttpGet]
        [Route("[Action]/{adminId}")]
        public IActionResult GetUserById(int adminId)
        {
            var admin = _userRepository.GetUserById(adminId);
            return admin != null ? Ok(admin) : NoContent();
        }


        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> CreateUser(Admin admin)
        {
            bool isCreated = await _userRepository.AddAsync(admin);
            if (isCreated == true)
            {
                return Ok("Admin Created Sucessfully.");
            }
            else
            {
                return Ok("Admin Creation Failed.");
            }
            
        }

        [HttpDelete]
        [Route("[Action]/{adminId}")]
        public async Task<IActionResult> DeleteUser(int adminId)
        {
            var admin = _userRepository.GetUserById(adminId);
            bool isDeleted = await _userRepository.DeleteAsync(admin);
            return Ok(isDeleted ? "Admin Deleted Sucessfully." : "admin Deletion Failed.");
        }
    }
}
