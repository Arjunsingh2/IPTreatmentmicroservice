using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPTreatmentMicroservice.Models
{
    public class Specialist
    {
        public Specialist()
        { }
        public int Id { get; set; }
        public string Name { get; set; }
        public string AreaOfExpertise { get; set; }
        public int Experience { get; set; }
        public long ContactNumber { get; set; }
    }
}
