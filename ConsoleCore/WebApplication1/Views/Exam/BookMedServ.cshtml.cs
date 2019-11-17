using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;

namespace WebApplication1.Views.Exam
{
    public class BookMedServModel : PageModel
    {
        private string _msg;

        public string Message
        {
            get => $"Передача запроса на резервирование номерка {_msg}";
            set => _msg = value;
        }

        [BindProperty]
        public BookMedicalServiceModel Booking { get; set; }

        public void OnGet()
        {
        }

        public void OnPost(string idLpu, long idPat, Guid idMedExam)
        {
            Message = $"ЛПУ: {idLpu}  Пацент: {idPat} Examination: {idMedExam}";
        }
    }
}