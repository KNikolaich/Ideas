using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DXWebApplication1.Models.Examination;

namespace DXWebApplication1.KostaN3Exam
{
    public partial class MedicalServiceBooking
    {
        public string MedicalServiceBookingStatusString => PlanRequest.GetMedicalServiceBookingStatus(MedicalServiceBookingStatus);
    }
}