using InternsManager.BL.Interfaces;
using InternsManager.TL.DTO;
using Microsoft.AspNetCore.Mvc;

namespace InternsManager.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserLogic _userLogic;

        public UserController(IUserLogic userLogic)
        {
            _userLogic = userLogic ?? throw new ArgumentNullException(nameof(userLogic));
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>a list of all users</returns>
        /// <response code="200">All users are listed</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Server problems</response>
        /// <response code="429">Too Many Requests</response>
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _userLogic.GetAll());
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param Name="id"></param>
        /// <returns>user</returns>
        /// <response code="200">user found</response>
        /// <response code="404">user not found</response>
        /// <response code="500">Server problems</response>
        /// <response code="429">Too Many Requests</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            return Ok(await _userLogic.GetById(id));
        }

        /// <summary>
        /// Create an user record
        /// </summary>
        /// <param Name="user"></param>
        /// <response code="200">User created</response>
        /// <response code="500">Server problems</response>
        /// <response code="429">Too Many Requests</response>
        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO user)
        {
            if (user == null)
            {
                return BadRequest("User record should not be null");
            }

            await _userLogic.AddUser(user);

            return Ok(await _userLogic.GetAll());
        }

        /// <summary>
        /// Update an user record
        /// </summary>
        /// <param Name="id"></param>
        /// <param Name="user"></param>
        /// <response code="200">User record was updated</response>
        /// <response code="404">The user record can't be created</response>
        /// <response code="400">The user record can't be null</response>
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] UserDTO user)
        {

            if (user == null)
            {
                return BadRequest("User record can't be null");
            }

            if (!await _userLogic.UpdateUser(id, user))
            {
                return NotFound("User record not found");
            }

            return Ok(await _userLogic.GetAll());
        }

        /// <summary>
        /// Delete an user record
        /// </summary>
        /// <param Name = "id" ></param >
        /// <response code="200">User record deleted</response>
        /// <response code="404">User record not found</response>

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            UserDTO user = await _userLogic.GetById(id);
            bool ok = await _userLogic.RemoveUser(user);

            if (!ok)
            {
                return NotFound("User Not Found");
            }

            return Ok("User deleted");
        }
    }
}
