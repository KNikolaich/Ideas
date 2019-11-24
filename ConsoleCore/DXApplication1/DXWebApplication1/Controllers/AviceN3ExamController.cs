using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DXWebApplication1.KostaN3Exam;
using DXWebApplication1.Models.Examination;

namespace DXWebApplication1.Controllers
{
    public class AviceN3ExamController : Controller
    {


        // GET: AviceN3Exam
        public ActionResult Plan()
        {
            return View(new PlanRequest()
            {
                IdPat = 26450,
                Servid = "FECA9BD1-CDBD-E911-80D0-20CF301DFD89"
            });
        }

        [HttpPost]
        public ActionResult Plan(PlanRequest plan)
        {
            plan.CalcRequest();
            return View("Plan", plan);
        }

        // GET: AviceN3Exam
        
        // GET: AviceN3Exam
        public ActionResult Index()
        {
            return RedirectToAction("Plan");
            return View("Plan", new PlanRequest()
            {
                IdPat = 26450,
                Servid = "FECA9BD1-CDBD-E911-80D0-20CF301DFD89"
            });
        }

        // GET: AviceN3Exam/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AviceN3Exam/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AviceN3Exam/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AviceN3Exam/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AviceN3Exam/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AviceN3Exam/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AviceN3Exam/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
