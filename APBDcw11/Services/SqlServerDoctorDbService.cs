using APBDcw11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBDcw11.Services
{
    public class SqlServerDoctorDbService : IDoctorDbService
    {
        private readonly DoctorDbContext _context;
        public SqlServerDoctorDbService(DoctorDbContext context)
        {
            _context = context;
        }
        public Doctor CreateDoctor(Doctor doctor)
        {
            var newDoctor = _context.AddAsync(doctor);
            _context.SaveChanges();
            return doctor;
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }
    }
}
