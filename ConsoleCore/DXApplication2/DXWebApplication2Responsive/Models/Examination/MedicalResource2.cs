using System;

namespace DXWebApplication2Responsive.AviceN3ExamServiceReference
{
    public partial class MedicalResource2
    {
        public string EmployeeNameSpeciality => MedicalEmployee.MedicalEmployeeNameSpeciality;
        
        public string EmployeeIdSpeciality => MedicalEmployee.MedicalEmployeeIdSpeciality;
        
        public string EmployeeFedIdSpeciality => MedicalEmployee.MedicalEmployeeFedIdSpeciality;
        public string EmployeeComment => MedicalEmployee.MedicalEmployeeComment;
        public string EmployeePositionCode => MedicalEmployee.MedicalEmployeePositionCode;
        public string EmployeeSnils => MedicalEmployee.MedicalEmployeeSnils;
        
        public string IdSlot => Slot()?.IdSlot.ToString();
        
        public string Address => Slot()?.Address;
        public string Room => Slot()?.Room;
        public DateTime? VisitStart => Slot()?.VisitStart;
        public DateTime? VisitEnd => Slot()?.VisitEnd;


        private Slot Slot()
        {
            if (ListSlot != null && ListSlot.Length > 0)
                return ListSlot[0];
            return null;
        }

    }
}