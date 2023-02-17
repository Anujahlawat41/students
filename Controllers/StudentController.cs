using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webAPI_Student.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webAPI_Student.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            return Ok(_context.Students.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var studentInDb = _context.Students.Find(id);
            if (studentInDb == null) return NotFound();
            return Ok(studentInDb);
        }
        [HttpPost]
        public IActionResult SaveStudents([FromBody]Student student)
        {
            if(student !=null && ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult UpdateStudent([FromBody]Student student)
        {
            if(student !=null && ModelState.IsValid)
            {
                _context.Students.Update(student);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudents(int id)
        {
            var studentInDb = _context.Students.Find(id);
            if (studentInDb == null) return NotFound();
            _context.Students.Remove(studentInDb);
            _context.SaveChanges();
            return Ok();
        }

    }
}

