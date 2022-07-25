using Educative.Core;
using Educative.Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Educative.API.Controllers
{
    public class AddressController : DefaultController
    {
        private readonly IAddressRepository _addressRepo;

        public AddressController(IAddressRepository addressRepo)
        {
            _addressRepo = addressRepo;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Address>))]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddressAll()
        {
            return Ok(await _addressRepo.GetAllAsync());
        }
        

        [HttpGet("{id}", Name = nameof(GetAddressById))]
        [ProducesResponseType(200, Type = typeof (Address))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Address>> GetAddressById(string id)
        {
            var student = await _addressRepo.GetByIdAsync(id);
            return Ok(student);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Address))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Address>> AddAddress(Address address)
        {
            if (address == null)
            {
                return BadRequest(); // 400 Bad request
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad request
            }
            Address added = await _addressRepo.AddAsync(address);
            return CreatedAtRoute(// 201 Created
            routeName: nameof(GetAddressById),
            routeValues: new { id = address.AddressId.ToLower() },
            value: added);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult>UpdateStudent(string id, [FromBody] Address address)
        {
            if (address == null || address.AddressId != id)
            {
                return BadRequest(); // 400 Bad request
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad request
            }

            var existing = await _addressRepo.GetByIdAsync(id);
            if (existing == null)
            {
                return NotFound(); // 404 Resource not found
            }
            await _addressRepo.UpdateAsync(id, address);
            return new NoContentResult(); // 204 No content
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<bool>> DeleteStudent(string id)
        {
            var existing = await _addressRepo.GetByIdAsync(id);
            if (existing == null)
            {
                return NotFound(); // 404 Resource not found
            }
            await _addressRepo.DeleteAsync(id);
            return new NoContentResult(); // 204 No content
        }
    }
}
