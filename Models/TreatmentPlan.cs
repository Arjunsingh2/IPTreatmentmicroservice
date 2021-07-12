using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPTreatmentMicroservice.Models
{
    
    public class TreatmentPlan
    {
        public TreatmentPlan()
        { this.Status = "Pending"; }
        public int Id { get; set; }
        public string PatientName { get; set; }
        public int PatientId { get; set; }
        public string Ailment { get; set; }
        public string PackageName { get; set; }
        public string TestDetails { get; set; }
        public int Cost { get; set; }
        public string Specialist { get; set; }
        public int SpecialistId { get; set; }
        public DateTime TreatmentCommencementDate { get; set; }
        public DateTime TreatmentEndDate { get; set; }
        public String Status { get; set; }
    }
}
