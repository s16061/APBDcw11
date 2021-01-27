using APBDcw11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBDcw11.Services
{
    interface IDoctorDbService
    {
        public Doctor CreateDoctor(Doctor doctor);
        public Doctor UpdateDoctor(Doctor doctor);
    }
}
