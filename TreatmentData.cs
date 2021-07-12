using IPTreatmentMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPTreatmentMicroservice
{
    public class TreatmentData
    {
        private static TreatmentDBContext _context;
        public TreatmentData(TreatmentDBContext context)
        {
            _context = context;
        }
        
        public static void TreatmentPlanData()
        {
            if(_context.TreatmentPlans.Any())
            {
                return;
            }
            _context.TreatmentPlans.AddRange(
                new TreatmentPlan
                {
                    Ailment = "Kidney Problem",
                    PackageName = "Package2",
                    TestDetails = "X-Ray",
                    Cost = 2500,
                    Specialist = "Vikash sharma",
                    TreatmentCommencementDate = new DateTime(2020, 03, 15),
                    TreatmentEndDate = new DateTime(2020, 03, 25)
                },
                 new TreatmentPlan
                 {
                     Ailment = "Headache",
                     PackageName = "Package2",
                     TestDetails = "X-Ray",
                     Cost = 6000,
                     Specialist = "Ravi sharma",
                     TreatmentCommencementDate = new DateTime(2020, 03, 15),
                     TreatmentEndDate = new DateTime(2020, 03, 25)
                 },
                 new TreatmentPlan
                 {
                     Ailment = "Toothache",
                     PackageName = "Package2",
                     TestDetails = "RCT",
                     Cost = 35000,
                     Specialist = "Shyam Kumar Chaturvedi",
                     TreatmentCommencementDate = new DateTime(2020, 01, 25),
                     TreatmentEndDate = new DateTime(2020, 03, 25)
                 },
                 new TreatmentPlan
                 {
                     Ailment = "Toothache",
                     PackageName = "Package1",
                     TestDetails = "Tooth Implant",
                     Cost = 3000,
                     Specialist = "Dhyan Chandra Shukla",
                     TreatmentCommencementDate = new DateTime(2020, 10, 05),
                     TreatmentEndDate = new DateTime(2021, 03, 15)
                 }

         );

            _context.SaveChanges();

        }

    }
}
