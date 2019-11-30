using System.Linq;
using System.Web.Mvc;
using DXWebApplication2Responsive.AviceN3ExamServiceReference;
using DXWebApplication2Responsive.Models.Examination;

namespace DXWebApplication2Responsive.Controllers
{
    public class AviceN3ExamController : Controller
    {


        // GET: AviceN3Exam
        public ActionResult Plan()
        {
            return View(new PlanRequest()
            {
                IdPat = 26450,
                Servid = "feca9bd1-cdbd-e911-80d0-20cf301dfd89"
            });
        }

        [HttpPost]
        public ActionResult Response(string servid, int idPat)
        {
            new PlanRequest { IdPat = idPat, Servid = servid}.CalcRequest();
            return PartialView("ResponsePlan", PlanRequest.Response);
        }

        // GET: AviceN3Exam
        
        // GET: AviceN3Exam
        public ActionResult Index()
        {
            return RedirectToAction("Plan");
        }
        

        [ValidateInput(false)]
        public ActionResult MedicalExaminationPartial(MedicalExamination model)
        {
            return PartialView("_MedicalExaminationPartial", model);
        }

        [ValidateInput(false)]
        public ActionResult MedicalServiceBookingPartial(string id)
        {
            var mService = PlanRequest.Response.MedicalExamination.ListMedicalService.FirstOrDefault(ms => ms.IdMedicalService.ToString() == id);
            MedicalServiceBooking booking = mService?.MedicalServiceBooking;
            //if (booking.IdMedicalServiceBooking == Guid.Empty)
            //    booking = null;
            return PartialView("_MedicalServiceBookingPartial", booking);
        }

        public ActionResult ListMedicalResource(string id)
        {
            var mService = PlanRequest.Response.MedicalExamination.ListMedicalService.FirstOrDefault(ms => ms.IdMedicalService.ToString() == id);
            MedicalServiceAvailableResource availableResource = mService?.MedicalServiceAvailableResource;
            ViewData["IdMedicalService"] = id;
            return PartialView("_MedicalServiceAvailableResourcePartial", availableResource);
        }
    }
}
