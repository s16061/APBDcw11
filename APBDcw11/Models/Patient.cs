using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APBDcw11.Models
{
    [Table("Patient")]
    public class Patient
    {
        public int IdPatient { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public ICollection<Prescription> Prescription { get; set; }

    }
}
