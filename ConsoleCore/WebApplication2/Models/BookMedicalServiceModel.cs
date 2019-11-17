using System;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Models
{
    public class BookMedicalServiceModel
    {

        [BindProperty(SupportsGet = true)]
        public string idLpu { get; set; }

        [BindProperty(SupportsGet = true)]
        public string idPat { get; set; }

        [BindProperty(Name = "idMedExam", SupportsGet = true)]
        public Guid idMedicalExamination { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid idMedicalService { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid idMedicalResource { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid idSlot { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime visitStart { get; set; }
    }
}
