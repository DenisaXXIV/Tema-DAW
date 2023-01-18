using InternsManager.BL.Interfaces;
using InternsManager.TL.DTO;
using Microsoft.AspNetCore.Mvc;

namespace InternsManager.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InternshipController : Controller
    {
        private readonly IInternshipLogic _internshipLogic;

        public InternshipController(IInternshipLogic internshipLogic)
        {
            _internshipLogic = internshipLogic ?? throw new ArgumentNullException(nameof(internshipLogic));
        }

        /// <summary>
        /// Get all internships
        /// </summary>
        /// <returns>a list of all internships</returns>
        /// <response code="200">All internships are listed</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Server problems</response>
        /// <response code="429">Too Many Requests</response>
        [HttpGet]
        public async Task<IActionResult> GetInternships()
        {
            return Ok(await _internshipLogic.GetAll());
        }


        /// <summary>
        /// Get internships by id
        /// </summary>
        /// <param Name="id"></param>
        /// <returns>internships</returns>
        /// <response code="200">internships found</response>
        /// <response code="404">internships not found</response>
        /// <response code="500">Server problems</response>
        /// <response code="429">Too Many Requests</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInternships([FromRoute] int id)
        {
            return Ok(await _internshipLogic.GetById(id));
        }

        /// <summary>
        /// Create an internships record
        /// </summary>
        /// <param Name="internships"></param>
        /// <response code="200">internships created</response>
        /// <response code="500">Server problems</response>
        /// <response code="429">Too Many Requests</response>
        [HttpPost("create")]
        public async Task<IActionResult> CreateInternships([FromBody] InternshipDTO internship)
        {
            if (internship == null)
            {
                return BadRequest("Internship record should not be null");
            }

            await _internshipLogic.AddInternship(internship);

            return Ok(await _internshipLogic.GetAll());
        }

        /// <summary>
        /// Update an internship record
        /// </summary>
        /// <param Name="id"></param>
        /// <param Name="internship"></param>
        /// <returns></returns>
        /// <response code="200">Internship record was updated</response>
        /// <response code="404">The Internship record can't be created</response>
        /// <response code="400">The Internship record can't be null</response>
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdatePerson([FromRoute] int id, [FromBody] InternshipDTO internship)
        {

            if (internship == null)
            {
                return BadRequest("Internship record can't be null");
            }

            if (!await _internshipLogic.UpdateInternship(id, internship))
            {
                return NotFound("Internship record not found");
            }

            return Ok(await _internshipLogic.GetAll());
        }

        /// <summary>
        /// Delete an Internship record
        /// </summary>
        /// <param Name = "id" ></param >
        /// <returns ></returns >
        /// <response code="200">Internship record deleted</response>
        /// <response code="404">Internship record not found</response>

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteInternship([FromRoute] int id)
        {
            InternshipDTO person = await _internshipLogic.GetById(id);
            bool ok = await _internshipLogic.RemoveInternship(person);

            if (!ok)
            {
                return NotFound("Internship record Not Found");
            }

            return Ok("Internship record deleted");
        }
    }
}
