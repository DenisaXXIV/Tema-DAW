using InternsManager.BL.Interfaces;
using InternsManager.TL.DTO;
using Microsoft.AspNetCore.Mvc;

namespace InternsManager.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InternController : Controller
    {
        private readonly IInternLogic _internLogic;

        public InternController(IInternLogic internLogic)
        {
            _internLogic = internLogic ?? throw new ArgumentNullException(nameof(internLogic));
        }

        /// <summary>
        /// Get all interns
        /// </summary>
        /// <returns>a list of all interns</returns>
        /// <response code="200">All interns are listed</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Server problems</response>
        /// <response code="429">Too Many Requests</response>
        [HttpGet]
        public async Task<IActionResult> GetInterns()
        {
            return Ok(await _internLogic.GetAll());
        }

        /// <summary>
        /// Get number of interns
        /// </summary>
        /// <returns>a number of interns</returns>
        /// <response code="200">a single number</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Server problems</response>
        /// <response code="429">Too Many Requests</response>
        [HttpGet("get-number")]
        public async Task<IActionResult> GetNumbers()
        {
            return Ok(await _internLogic.GetNumberInterns());
        }


        /// <summary>
        /// Get intern by id
        /// </summary>
        /// <param Name="id"></param>
        /// <returns>intern</returns>
        /// <response code="200">intern found</response>
        /// <response code="404">intern not found</response>
        /// <response code="500">Server problems</response>
        /// <response code="429">Too Many Requests</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIntern([FromRoute] int id)
        {
            return Ok(await _internLogic.GetById(id));
        }

        /// <summary>
        /// Create an intern record
        /// </summary>
        /// <param Name="intern"></param>
        /// <response code="200">intern created</response>
        /// <response code="500">Server problems</response>
        /// <response code="429">Too Many Requests</response>
        [HttpPost("create")]
        public async Task<IActionResult> CreateIntern([FromBody] InternDTO intern)
        {
            if (intern == null)
            {
                return BadRequest("Intern record should not be null");
            }

            await _internLogic.AddIntern(intern);

            return Ok(await _internLogic.GetAll());
        }

        /// <summary>
        /// Update an intern record
        /// </summary>
        /// <param Name="id"></param>
        /// <param Name="intern"></param>
        /// <returns></returns>
        /// <response code="200">Intern record was updated</response>
        /// <response code="404">The intern record can't be created</response>
        /// <response code="400">The intern record can't be null</response>
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateIntern([FromRoute] int id, [FromBody] InternDTO intern)
        {

            if (intern == null)
            {
                return BadRequest("Intern record can't be null");
            }

            if (!await _internLogic.UpdateIntern(id, intern))
            {
                return NotFound("Intern record not found");
            }

            return Ok(await _internLogic.GetAll());
        }

        /// <summary>
        /// Delete an intern record
        /// </summary>
        /// <param Name = "id" ></param >
        /// <returns ></returns >
        /// <response code="200">Intern record deleted</response>
        /// <response code="404">Intern record not found</response>

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteIntern([FromRoute] int id)
        {
            InternDTO intern = await _internLogic.GetById(id);
            bool ok = await _internLogic.RemoveIntern(intern);

            if (!ok)
            {
                return NotFound("Intern record Not Found");
            }

            return Ok("Intern record deleted");
        }
    }
}
