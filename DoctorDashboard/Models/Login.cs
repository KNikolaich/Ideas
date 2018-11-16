using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorDashboard.Models
{
    public class Login
    {
        public string Person { get; set; }

        public string Password { get; set; }

        public object FormData { get; set; }
    }
}