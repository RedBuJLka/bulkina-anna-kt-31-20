using BulkinaAnnaKT_31_20.Database;
using BulkinaAnnaKT_31_20.Filters.StudentFilters;
using BulkinaAnnaKT_31_20.Interfaces.StudentsInterfaces;
using BulkinaAnnaKT_31_20.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BulkinaAnnaKT_31_20.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly IStudentService _studentService;
        public StudentDbContext _dbcontext;

        public StudentsController(ILogger<StudentsController> logger, IStudentService studentService, StudentDbContext context)
        {
            _logger = logger;
            _studentService = studentService;
            _dbcontext = context;
        }

        [HttpPost(Name = "GetStudentsBuGroup")]
        public async Task<IActionResult> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken) {

            var students = await _studentService.GetStudentsByGroupAsync(filter, cancellationToken);
            return Ok(students);
        }


        [HttpPost("AddStudent", Name = "AddStudent")]
        public IActionResult CreateStudent([FromBody] StudentAddFilter filter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var student = new Student();
            student.Name = filter.Name;
            student.Surname = filter.Surname;
            student.Patronym = filter.Patronym;
            student.GroupId = _dbcontext.Groups.FirstOrDefault(g => g.GroupName == filter.GroupName).GroupId;

            _dbcontext.Students.Add(student);
            _dbcontext.SaveChanges();
            return Ok(student);
        }

        [HttpPut("EditStudent")]
        public IActionResult UpdateStudent(int id, [FromBody] StudentAddFilter filter)
        {
            var existingStudent = _dbcontext.Students.FirstOrDefault(g => g.StudentId == id);

            if (existingStudent == null)
            {
                return NotFound();
            }

            existingStudent.Name = filter.Name;
            existingStudent.Surname = filter.Surname;
            existingStudent.Patronym = filter.Patronym;
            existingStudent.GroupId = _dbcontext.Groups.FirstOrDefault(g => g.GroupName == filter.GroupName).GroupId;
            _dbcontext.SaveChanges();

            return Ok();
        }

        [HttpDelete("DeleteStudent")]
        public IActionResult DeleteGroup(int id)
        {
            var existingStudent = _dbcontext.Students.FirstOrDefault(g => g.StudentId == id);

            if (existingStudent == null)
            {
                return NotFound();
            }
            _dbcontext.Students.Remove(existingStudent);
            _dbcontext.SaveChanges();

            return Ok();
        }
    }
}