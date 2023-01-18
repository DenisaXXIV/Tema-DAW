using InternsManager.BL.Interfaces;
using InternsManager.TL.DTO;
using Microsoft.AspNetCore.Mvc;

namespace InternsManager.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IRoleLogic _roleLogic;

        public RoleController(IRoleLogic roleLogic)
        {
            _roleLogic = roleLogic ?? throw new ArgumentNullException(nameof(roleLogic));
        }

        /// <summary>
        /// Get all roles
        /// </summary>
        /// <returns>a list of all roles</returns>
        /// <response code="200">All roles are listed</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Server problems</response>
        /// <response code="429">Too Many Requests</response>
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            return Ok(await _roleLogic.GetAll());
        }


        /// <summary>
        /// Get role by id
        /// </summary>
        /// <param Name="id"></param>
        /// <returns>role</returns>
        /// <response code="200">role found</response>
        /// <response code="404">role not found</response>
        /// <response code="500">Server problems</response>
        /// <response code="429">Too Many Requests</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRole([FromRoute] int id)
        {
            return Ok(await _roleLogic.GetById(id));
        }

        /// <summary>
        /// Create role
        /// </summary>
        /// <param Name="role"></param>
        /// <response code="200">role created</response>
        /// <response code="500">Server problems</response>
        /// <response code="429">Too Many Requests</response>
        [HttpPost("create")]
        public async Task<IActionResult> CreateRole([FromBody] RoleDTO role)
        {
            if (role == null)
            {
                return BadRequest("Role record should not be null");
            }

            await _roleLogic.AddRole(role);

            return Ok(await _roleLogic.GetAll());
        }

        /// <summary>
        /// Update role
        /// </summary>
        /// <param Name="id"></param>
        /// <param Name="role"></param>
        /// <response code="200">Role record was updated</response>
        /// <response code="404">Role can't be created</response>
        /// <response code="400">Role can't be null</response>
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdatePerson([FromRoute] int id, [FromBody] RoleDTO role)
        {

            if (role == null)
            {
                return BadRequest("Role record can't be null");
            }

            if (!await _roleLogic.UpdateRole(id, role))
            {
                return NotFound("Role record not found");
            }

            return Ok(await _roleLogic.GetAll());
        }

        /// <summary>
        /// Delete role
        /// </summary>
        /// <param Name = "id" ></param >
        /// <response code="200">Role deleted</response>
        /// <response code="404">Role not found</response>

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteRole([FromRoute] int id)
        {
            RoleDTO role = await _roleLogic.GetById(id);
            bool ok = await _roleLogic.RemoveRole(role);

            if (!ok)
            {
                return NotFound("Role Not Found");
            }

            return Ok("Role deleted");
        }
    }
}

