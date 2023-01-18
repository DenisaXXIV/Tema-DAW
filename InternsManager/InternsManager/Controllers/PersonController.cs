using InternsManager.BL.Interfaces;
using InternsManager.TL.DTO;
using Microsoft.AspNetCore.Mvc;

namespace InternsManager.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IPersonLogic _personLogic;

        public PersonController(IPersonLogic personLogic)
        {
            _personLogic = personLogic ?? throw new ArgumentNullException(nameof(personLogic));
        }

        /// <summary>
        /// Get all persons
        /// </summary>
        /// <returns>a list of all interns</returns>
        /// <response code="200">All persons are listed</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Server problems</response>
        /// <response code="429">Too Many Requests</response>
        [HttpGet]
        public async Task<IActionResult> GetPersons()
        {
            return Ok(await _personLogic.GetAll());
        }


        /// <summary>
        /// Get person by id
        /// </summary>
        /// <param Name="id"></param>
        /// <returns>person</returns>
        /// <response code="200">person found</response>
        /// <response code="404">person not found</response>
        /// <response code="500">Server problems</response>
        /// <response code="429">Too Many Requests</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson([FromRoute] int id)
        {
            return Ok(await _personLogic.GetById(id));
        }

        /// <summary>
        /// Create an person record
        /// </summary>
        /// <param Name="person"></param>
        /// <response code="200">person created</response>
        /// <response code="500">Server problems</response>
        /// <response code="429">Too Many Requests</response>
        [HttpPost("create")]
        public async Task<IActionResult> CreatePerson([FromBody] PersonDTO person)
        {
            if (person == null)
            {
                return BadRequest("Person record should not be null");
            }

            await _personLogic.AddPerson(person);

            return Ok(await _personLogic.GetAll());
        }

        /// <summary>
        /// Update an person record
        /// </summary>
        /// <param Name="id"></param>
        /// <param Name="person"></param>
        /// <returns></returns>
        /// <response code="200">Person record was updated</response>
        /// <response code="404">The person record can't be created</response>
        /// <response code="400">The person record can't be null</response>
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdatePerson([FromRoute] int id, [FromBody] PersonDTO person)
        {

            if (person == null)
            {
                return BadRequest("Person record can't be null");
            }

            if (!await _personLogic.UpdatePerson(id, person))
            {
                return NotFound("Person record not found");
            }

            return Ok(await _personLogic.GetAll());
        }

        /// <summary>
        /// Delete an person record
        /// </summary>
        /// <param Name = "id" ></param >
        /// <returns ></returns >
        /// <response code="200">Person record deleted</response>
        /// <response code="404">Person record not found</response>

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeletePerson([FromRoute] int id)
        {
            PersonDTO person = await _personLogic.GetById(id);
            bool ok = await _personLogic.RemovePerson(person);

            if (!ok)
            {
                return NotFound("Person record Not Found");
            }

            return Ok("Person record deleted");
        }
    }
}
