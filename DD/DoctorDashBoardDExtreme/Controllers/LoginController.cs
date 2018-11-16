using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoctorDashBoardDExtreme.Models;

namespace DoctorDashboard.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View(new Login
            {
                FormData = new
                {
                    ID = 1,
                    FirstName = "John",
                    LastName = "Heart",
                    CompanyName = "Super Mart of the West",
                    Position = "CEO",
                    OfficeNo = "901",
                    BirthDate = new DateTime(1964, 3, 16),
                    HireDate = new DateTime(1995, 1, 15),
                    Address = "351 S Hill St.",
                    City = "Los Angeles",
                    State = "CA",
                    Zipcode = "90013",
                    Phone = "+1(213) 555-9392",
                    Email = "jheart@dx-email.com",
                    Skype = "jheart_DX_skype"
                }
            });
        }
    }
}