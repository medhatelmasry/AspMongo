using System.Collections.Generic;
using AspMongo.Models;
using AspMongo.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspMongo.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase {
        private readonly StudentService _StudentService;

        public StudentsController(StudentService Studentservice)
        {
            _StudentService = Studentservice;
        }

        [HttpGet]
        public ActionResult<List<Student>> Get() =>
            _StudentService.Get();

        [HttpGet("{id:length(24)}", Name = "GetStudent")]
        public ActionResult<Student> Get(string id)
        {
            var student = _StudentService.Get(id);

            if (student == null)
                return NotFound();

            return student;
        }

        [HttpPost]
        public ActionResult<Student> Create(Student student)
        {
            _StudentService.Create(student);

            return CreatedAtRoute("GetStudent", new { id = student.StudentId.ToString() }, student);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Student studentIn)
        {
            var student = _StudentService.Get(id);

            if (student == null)
                return NotFound();

            _StudentService.Update(id, studentIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var student = _StudentService.Get(id);

            if (student == null)
                return NotFound();

            _StudentService.Remove(student.StudentId);

            return NoContent();
        }
    }
}