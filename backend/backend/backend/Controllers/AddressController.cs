using Microsoft.AspNetCore.Mvc;
using backend.Services; 
using backend.Models;
using System.Collections.Generic;

namespace backend.Controllers
{
    [ApiController]
    [Route("address")]
    public class AddressController(AddressService _addressService) : ControllerBase
    {
        [HttpGet("person/{personId}")]
        public ActionResult<List<Address>> GetAddressesByPersonId(int personId)
        {
            var addresses = _addressService.GetAddressesByPersonId(personId);
            if (addresses == null || addresses.Count == 0)
            {
                return NotFound($"No addresses found for person ID {personId}.");
            }

            return Ok(addresses); // Return the list of addresses for the specified person
        }
    }
}
