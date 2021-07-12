using IPTreatmentMicroservice.Models;
using IPTreatmentMicroservice.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace IPTreatmentMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TreatmentController : ControllerBase
    {
        private readonly TreatmentDBContext context;
        private readonly TreatmentRepo repo;
        public TreatmentController(TreatmentDBContext cont)
        {
            context = cont;
            repo = new TreatmentRepo(cont);
        }


        //[Route("FormulateTreatmentTimetable/{Ailment}")]
        [HttpPost("fmt")]
        [Authorize]
        public async Task<IActionResult> FormulateTreatmentTimetable([FromBody] Patient patient)
        {


            TreatmentPlan plan = new TreatmentPlan();
            TreatmentPackage pack = new TreatmentPackage();
            Specialist sp = new Specialist();
            string designation = "Senior";
            if (patient.Package == "Package1")
                designation = "Junior";

            //consume IPoffering microservice for package details

            using (var client = new HttpClient())
            {

                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.BaseAddress = new Uri("https://ipoffering.azurewebsites.net/api/");
                var result = await client.GetAsync("Offering/GetPackagetype/" + patient.Ailment + "/" + patient.Package);
                //   https://localhost:44347/api/Offering/GetPackagetype?ailment=Gastro&package=Package%201
                if (result.IsSuccessStatusCode)
                {
                    var jsoncontent = await result.Content.ReadAsStringAsync();
                    pack = JsonConvert.DeserializeObject<TreatmentPackage>(jsoncontent);
                }
            }
            //consume IPOffering Microservice for specialist details
            using (var client = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.BaseAddress = new Uri("https://ipoffering.azurewebsites.net/api/");

                var result = await client.GetAsync("Offering/GetSpecialisttype/" + patient.Ailment + "/" + designation);
                //  https://localhost:44347/api/Offering/GetSpecialisttype?ailment=Gastro&design=Junior
                if (result.IsSuccessStatusCode)
                {
                    var jsoncontent = await result.Content.ReadAsStringAsync();
                    sp = JsonConvert.DeserializeObject<Specialist>(jsoncontent);
                }
            }
            try
            {
                plan.PatientName = patient.Name;
                plan.Ailment = patient.Ailment;
                plan.PatientId = patient.Id;
                plan.PackageName = patient.Package;
                plan.TestDetails = pack.TestDetail;
                plan.Cost = pack.Cost;
                plan.Specialist = sp.Name;
                plan.SpecialistId = sp.Id;
                plan.TreatmentCommencementDate = patient.TreatmentCommencementDate;
                plan.TreatmentEndDate = patient.TreatmentCommencementDate.AddDays(pack.Duration * 7);
                repo.Addtodb(plan);
                return Ok(plan);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Fetching Data");
            }
        }
        [HttpGet("getallplans")]
        [Authorize]
        public IActionResult GetAllPlans()
        {
            return Ok(context.TreatmentPlans.Where(p => p.Status == "Pending").ToList());
        }
        [HttpGet("MarkCompleted/{id}")]
        [Authorize]
        public IActionResult MarkCompleted(int id)
        {
            TreatmentPlan plan = context.TreatmentPlans.Where(p => p.Id == id).FirstOrDefault();
            plan.Status = "Completed";
            int SpecialistId = plan.SpecialistId;
            context.SaveChanges();
            return Ok(SpecialistId);
        }
        [HttpGet("History")]
        [Authorize]
        public IActionResult History()
        {
            return Ok(context.TreatmentPlans.Where(p => p.Status == "Completed").ToList());
        }
    }
}















//[HttpGet]
//public async Task<IActionResult> FormulateTreatmentTimetable(string Name,int Age,string Ailment, String Package,DateTime TreatmentCommencementDate)
//{

//    TreatmentPlan plan = new TreatmentPlan();
//    TreatmentPackage pack = new TreatmentPackage();
//    Specialist sp = new Specialist();
//    string designation = "Senior";
//    if (Package == "Package 1")
//        designation = "Junior";

//    //consume IPoffering microservice for package details

//    using (var client = new HttpClient())
//    {

//        var contentType = new MediaTypeWithQualityHeaderValue("application/json");
//        client.DefaultRequestHeaders.Accept.Add(contentType);


//        client.BaseAddress = new Uri("https://localhost:44347/api/");

//        var result = await client.GetAsync("Offering/GetPackagetype?ailment=" +Ailment + "&package=" + Package);
//        //   https://localhost:44347/api/Offering/GetPackagetype?ailment=Gastro&package=Package%201
//        if (result.IsSuccessStatusCode)
//        {

//            var jsoncontent = await result.Content.ReadAsStringAsync();
//            pack = JsonConvert.DeserializeObject<TreatmentPackage>(jsoncontent);

//        }
//    }

//    //consume IPOffering Microservice for specialist details
//    using (var client = new HttpClient())
//    {

//        var contentType = new MediaTypeWithQualityHeaderValue("application/json");
//        client.DefaultRequestHeaders.Accept.Add(contentType);


//        client.BaseAddress = new Uri("https://localhost:44347/api/");

//        var result = await client.GetAsync("Offering/GetSpecialisttype/?ailment=" + Ailment + "&design=" + designation);
//        //  https://localhost:44347/api/Offering/GetSpecialisttype?ailment=Gastro&design=Junior
//        if (result.IsSuccessStatusCode)
//        {

//            var jsoncontent = await result.Content.ReadAsStringAsync();
//            sp = JsonConvert.DeserializeObject<Specialist>(jsoncontent);

//            //readTask.Wait();
//        }
//    }
//    try
//    {
//        //var a = _treatmentRepository.GetTreatmentPlan(Ailment);
//        //return new OkObjectResult(a);
//        plan.PatientName = Name;
//        plan.Ailment = Ailment;
//        plan.PackageName = Package;
//        plan.TestDetails = pack.TestDetail;
//        plan.Cost = pack.Cost;
//        plan.Specialist = sp.Name;
//        plan.TreatmentCommencementDate = TreatmentCommencementDate;
//        plan.TreatmentEndDate =TreatmentCommencementDate.AddDays(pack.duration * 7);
//        repo.Addtodb(plan);
//        return Ok(plan);
//    }
//    catch (Exception)
//    {
//        return StatusCode(StatusCodes.Status500InternalServerError, "Error in Fetching Data");
//    }
//}
