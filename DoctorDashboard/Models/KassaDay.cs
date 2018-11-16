using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorDashboard.Models
{
	// Касса
    public class KassaDay
    {
        public DateTime Date { get; set; }
        public double Cach { get; set; }
        public decimal Oms { get; set; }
        public decimal Dms { get; set; }

    }
}