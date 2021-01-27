using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APBDcw11.Models
{
    [Table("Medicament")]

    public class Medicament
    {
        public int IdMedicament { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public ICollection<Prescription_Medicament> Prescription_Medicament { get; set; }

    }
}
