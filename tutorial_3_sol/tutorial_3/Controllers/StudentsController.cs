using System;
using Microsoft.AspNetCore.Mvc;
using tutorial_3.DAL;
using tutorial_3.Models;

namespace tutorial_3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetStudent(string orderBy)
        {
            return Ok(_dbService.GetStudents());
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            if(id == 1)
            {
                return Ok("Kowalski");
            } else if(id == 2)
            {
                return Ok("Malewski");
            }

            return NotFound("Student is not found");

        }

        //fix unsupported media type
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 2000)}";
            return Ok(student);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteMethod(int id)
        {
            return Ok("Delete completed");
        }

        [HttpPut("{id}")]
        public IActionResult PutMethod(int id)
        {
            return Ok("Update completed");
        }

    }
}
