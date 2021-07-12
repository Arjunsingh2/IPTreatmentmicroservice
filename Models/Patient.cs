using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPTreatmentMicroservice.Models
{
    public class Patient
    {
        public Patient()
        { }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Ailment { get; set; }
        public string Package { get; set; }
        public DateTime TreatmentCommencementDate { get; set; }
    }
}
