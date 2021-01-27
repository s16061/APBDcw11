using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBDcw11.DTOs.Request;
using APBDcw11.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APBDcw11.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : Controller
    {
        private readonly DoctorDbContext _context;
        public DoctorController(DoctorDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_context.Doctors.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetDoctor(int id)
        {
            var res = _context.Doctors
                .Where(doctors => doctors.IdDoctor == id)
                .Select(doctors => new
                {
                    doctors.IdDoctor,
                    doctors.FirstName,
                    doctors.LastName,
                    doctors.Email
                }).ToList();
            return Ok(res);
        }

        [HttpPost]
        public IActionResult CreateDoctor(CreateDoctorRequest request)
        {
            var res = new Doctor
            {
                FirstName = request.FirstName,
                LastName=request.LastName,
                Email=request.Email
            };
            _context.Doctors.Add(res);
            _context.SaveChanges();
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            var res = new Doctor
            {
                IdDoctor = id
            };
            _context.Attach(res);
            _context.Remove(res);
            _context.SaveChangesAsync();
            return Ok("Deleted");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDoctor(int id, UpdateDoctorRequest request)
        {
            var doc = _context.Doctors.Where(d => d.IdDoctor == id).FirstOrDefault();
            doc.FirstName = request.FirstName;
            doc.LastName = request.LastName;
            doc.Email = request.Email;
            _context.SaveChanges();
            return Ok("Updated");

        }
    }
}