using Microsoft.AspNetCore.Mvc;
using backend.Services; 
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("persons")]
    public class PersonController(PersonService _personService) : ControllerBase
    {
        [HttpGet("all")]
        public ActionResult<List<Person>> GetAll()
        {
            var persons = _personService.GetAllPeople();
            return Ok(persons); 
        }

        [HttpPost("add")]
        public ActionResult<Person> AddPerson([FromBody] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Name cannot be empty.");
            }

            var personId = _personService.AddPerson(name); 
            var newPerson = _personService.GetPerson(personId); 

            return Ok(newPerson); 
        }
    }
}
