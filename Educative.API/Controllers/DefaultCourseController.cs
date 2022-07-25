using Educative.Core;
using Educative.Infrastructure.Interface;
using Educative.API.Errors;
using Microsoft.AspNetCore.Mvc;
using Educative.Infrastructure.Helpers;
using System.Text.Json;

namespace Educative.API.Controllers
{
    
    public class DefaultCourseController : DefaultController
    {
        private readonly IUnitOfWork _unitOfWork;

        public DefaultCourseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof (IEnumerable<Course>))]
        public async Task<ActionResult<IEnumerable<Course>>> GetAllCourse([FromQuery] CourseParams courseParams)
        {

            var courses = await _unitOfWork.CourseRepository.GetAllCourses(courseParams);

            Response.Headers.Add("Pagination", JsonSerializer.Serialize(courses.MetaData));

            Response.Headers.Add("Access-Control-Expose-Headers", "Pagination");


            return Ok(courses);
        }

        [HttpGet("{id}", Name = nameof(GetCourseById))]
        [ProducesResponseType(200, Type = typeof (Course))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Course>> GetCourseById(string id)
        {
            var course = await _unitOfWork.CourseRepository.GetByIdAsync(id);
            if(course == null){
                return NotFound(new HttpErrorException(404));
            }
            return Ok(course);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof (Course))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Course>> AddCourse(Course course)
        {
            if (course == null)
            {
                return BadRequest(new HttpErrorException(400)); // 400 Bad request
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad request
            }
            var added = await _unitOfWork.CourseRepository.AddAsync(course);
            return CreatedAtRoute(// 201 Created
            routeName: nameof(GetCourseById),
            routeValues: new { id = course.CourseId.ToLower() },
            value: added);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Course>>UpdateCourse(string id, [FromBody]Course course)
        {
            if (course == null)
                return BadRequest(new HttpErrorException(400)); // 400 Bad request

            var existing = await _unitOfWork.CourseRepository.GetByIdAsync(id);
            if (existing == null)
            {
                return NotFound(new HttpErrorException(404)); // 404 Resource not found
            }
            await _unitOfWork.CourseRepository.UpdateAsync(id, course);
            return new NoContentResult(); // 204 No content
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<bool>> DeleteCourse(string id)
        {
            var existing = await _unitOfWork.CourseRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound(new HttpErrorException(404)); // 404 Resource not found

            await _unitOfWork.CourseRepository.DeleteAsync(id);
            return NoContent(); // 204 No content
        }

        
    }
}
