using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Models
{
    public class BookMedicalServiceModel
    {

        [BindProperty(SupportsGet = true)]
        public string idLpu { get; set; }

        [BindProperty(SupportsGet = true)]
        public long idPat { get; set; }

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
