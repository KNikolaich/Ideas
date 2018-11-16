using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorDashboard.Models
{
    public class HospitalDep
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }

        // прибыло
        public string Received { get; set; }
        // умерло
        public string Death { get; set; }
        // переведено в другие стационары
        public string Transferred { get; set; }
        // Выписано
        public string Discharged { get; set; }

        public string Website { get; set; }
    }
}