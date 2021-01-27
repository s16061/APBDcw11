using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APBDcw11.Models
{
    [Table("Prescription")]
    public class Prescription
    {
        public int IdPrescription { get; set; }

        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }

        public ICollection<Prescription_Medicament> Prescription_Medicament { get; set; }

        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }

    }
}
