using System;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebApplication2.Models;

namespace WebApplication2.Pages
{
    public class BookMedServModel : PageModel
    {
        private string _msg;

        public string Message
        {
            get => $"Передача запроса на резервирование номерка {_msg}";
            set => _msg = value;
        }

        public string Result { get; set; }

        [BindProperty]
        public BookMedicalServiceModel Booking { get; set; }

        public void OnGet()
        {
            Booking = new BookMedicalServiceModel()
            {
                idLpu = "17",
                idPat = "26450",
                idMedicalExamination = new Guid("5e62da4f-70f9-e911-80df-20cf301dfd89"),
                idMedicalService = new Guid("cc0bf976-8af1-e911-80df-20cf301dfd89"),
                idMedicalResource = new Guid("65d0582c-dde7-4d7f-a5a1-2079bd3e05ab"),
                idSlot = new Guid("4e15300c-a500-ea11-ab3a-002590187b6d"),
                visitStart = DateTime.Now.AddHours(1)
            };
        }

        public void OnPost(string idLpu, string idPat, System.Guid idMedExam, System.Guid idMedicalService, System.Guid idMedicalResource, System.Guid idSlot, System.Nullable<System.DateTime> visitStart, System.Guid guid)
        {
           //string idLpu , string idPat, System.Guid idMedExam, System.Guid idMedicalService, System.Guid idMedicalResource, System.Guid idSlot, System.Nullable<System.DateTime> visitStart, System.Guid guid
           var client = new ExamClient.Methods();
           var result = client.BookingAsync(idLpu, idPat, idMedExam, idMedicalService, idMedicalResource, idSlot, visitStart, guid).Result;
            Result = result.Success ? result.MedicalService.ToString() : result.ToString();
           Message = $"ЛПУ: {idLpu}  Пацент: {idPat} Examination: {idMedExam}";
        }
    }
}