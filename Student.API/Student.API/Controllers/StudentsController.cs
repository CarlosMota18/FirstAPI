using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.API.Entities;
using Student.API.Services;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Student.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        readonly IServices<Students> _studentServices;
        
        public StudentsController(IServices<Students> services)
        {
            _studentServices = services;
        }
        [HttpGet]
        public IEnumerable<Students> get()
        {
            return _studentServices.GetList();
        }
        [HttpGet("{GetById}")]
        public Students GetById([FromRoute] Guid id)
        {
            return _studentServices.GetByID(id);
        }
        [HttpPost("{Add}")]
        public IActionResult Post([FromBody] Students value)
        {
             _studentServices.Add(value);
            return Ok();
        }
        [HttpPut("{Update}")]
        public IActionResult Put([FromBody] Students student)
        {
            _studentServices.Update(student);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]Guid id)
        {
            _studentServices.Remove(id);
            return Ok();
        }
    }
}
