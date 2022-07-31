using Educative.API.Errors;
using Educative.API.Filter;
using Educative.Core;
using Educative.Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Educative.API.Controllers
{
    public class StudentController : DefaultController
    {
        
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Student>))]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var students = await _unitOfWork.StudentRepository.GetAllAsync();

            return Ok(students);
        }

        [HttpGet("{id}", Name = nameof(GetStudentById))]
        [ProducesResponseType(200, Type = typeof (Student))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Student>> GetStudentById(string id)
        {

           
            if(id == null)
                return BadRequest(new HttpErrorException(400)); // 400 bad request made


            var student = await _unitOfWork.StudentRepository.GetByIdAsync(id);
            
            if(student == null)
                return NotFound(new HttpErrorException(404)); // 404 Resource not found
            

            if(student.StudentId != id)
                return NotFound(new HttpErrorException(400)); // 400 Bad request
            

            return Ok(student);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof (Student))]
        [HttpDbExceptionFilter]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Student>> AddStudent(Student student)
        {
            if (student == null && !ModelState.IsValid)
                return BadRequest(new HttpErrorException(400)); // 400 Bad request

            Student added = await _unitOfWork.StudentRepository.AddAsync(student);
            return CreatedAtRoute(// 201 Created
            routeName: nameof(GetStudentById),
            routeValues: new { id = student.StudentId.ToLower() },
            value: added);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult>
        UpdateStudent(string id, [FromBody] Student student)
        {
            if (student == null || student.StudentId != id)
            {
                return BadRequest(new HttpErrorException(400)); // 400 Bad request
            }
            if (!ModelState.IsValid)
                return BadRequest(new HttpErrorException(400)); // 400 Bad request
       

            var existing = await _unitOfWork.StudentRepository.GetByIdAsync(id);

            if (existing is null)
                return NotFound(new HttpErrorException(404)); // 404 Not Found Resource 
        
            await _unitOfWork.StudentRepository.UpdateAsync(id, student);
            return new NoContentResult(); // 204 No content
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteStudent(string id)
        {
            var existing = await _unitOfWork.StudentRepository.GetByIdAsync(id);

            if (existing is null)
                return NotFound(new HttpErrorException(404)); // 404 Resource not found

            if(id != existing.StudentId)
                return BadRequest(new HttpErrorException(400)); // 400 Bad request

            await _unitOfWork.StudentRepository.DeleteAsync(id);
            return new NoContentResult(); // 204 No content
        }
    }
}
