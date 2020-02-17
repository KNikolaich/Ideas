

using DXWebApplication2Responsive.Models.Examination;

namespace DXWebApplication2Responsive.AviceN3ExamServiceReference
{
    public partial class MedicalServiceBooking
    {
        public string MedicalServiceBookingStatusString => PlanRequest.GetMedicalServiceBookingStatus(MedicalServiceBookingStatus);
    }
}