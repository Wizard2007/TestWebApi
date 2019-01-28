using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Data.Abstractions;
using Test.Data.Models;

namespace Test.Web.Api.Controllers
{
    //
    //https://code-maze.com/async-generic-repository-pattern/
    //https://blog.usejournal.com/enumeration-in-net-d5674921512e 
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUnitOfWork _unitOfwork;
        IUserRepository _userRepository;
        public UsersController(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _unitOfwork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll() => Ok(await _userRepository.GetAllAsync());

        [HttpPost("createuser")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            await _userRepository.AddAsync(user);
            await _unitOfwork.CommitAsync();

            return Ok();
        }
    }
}