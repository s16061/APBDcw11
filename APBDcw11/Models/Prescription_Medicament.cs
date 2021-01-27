using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APBDcw11.Models
{
    [Table("Prescription_Medicament")]
    public class Prescription_Medicament
    {
        
        public int IdMedicament { get; set; }
 
        public int IdPrescription { get; set; }
        public int Dose { get; set; }
        public string Details { get; set; }

        public Medicament Medicament { get; set; }
        public Prescription Prescription { get; set; }
    }
}
