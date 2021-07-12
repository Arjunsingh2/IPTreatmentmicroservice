using IPTreatmentMicroservice.Models;
//using IPTreatmentMicroservice.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPTreatmentMicroservice.Repositories
{
    public class TreatmentRepo : ITreatmentRepo
    {
        private static TreatmentDBContext _context;

        public TreatmentRepo()
        {
        }

        public TreatmentRepo(TreatmentDBContext context)
        {
            _context = context;
        }   
        public void Addtodb(TreatmentPlan plan)
        {
            _context.Add(plan);
            _context.SaveChanges();
        }
            
   
        
        //public IEnumerable<TreatmentPlan> GetTreatmentPlan(string ailment)
        //{
        //    return _context.TreatmentPlans.Where(t => t.Ailment == ailment );
        //}
    }
}
