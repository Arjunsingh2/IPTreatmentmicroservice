using IPTreatmentMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPTreatmentMicroservice.Repositories
{
    public interface ITreatmentRepo
    {
        // public IEnumerable<TreatmentPlan> GetTreatmentPlan(string ailment,string packageName);
        //public IEnumerable<TreatmentPlan> GetTreatmentPlan(string ailment);
        public void Addtodb(TreatmentPlan plan);
    }
}
