using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPTreatmentMicroservice.Models
{
    public class TreatmentPackage
    {
        public TreatmentPackage()
        { }
        public int Id { get; set; }
        public String Ailment { get; set; }
        public string Package { get; set; }
        public String TestDetail { get; set; }
        public int Cost { get; set; }
        public int Duration { get; set; }
    }
}
