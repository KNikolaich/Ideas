using System;
using System.Collections.Generic;

namespace DoctorDashboard.Models
{
    public class MockData
    {

        public static List<HospitalDep> Dapartments = new List<HospitalDep> {
            new HospitalDep {
                ID = 1,
                Name = "Приемное",
                Received = "1283", // Поступило
                //State = "Arkansas",
                //FreeBeds = "", // Свободных мест
                Transferred = "23",
                Discharged = "1260",
                Death = "85",
            },
            new HospitalDep {
                ID = 2,
                Name = "Хирургическое",
                Received = "803", // Поступило
                //FreeBeds = "6", // Свободных мест
                Transferred = "23", // На отделении
                Discharged = "780", // Выбыло
                Death = "12", // Умерло
            },
            new HospitalDep {
                ID = 3,
                Name = "Терапевтическое",
                Received = "306", // Поступило
                //FreeBeds = "0", // Свободных мест
                Transferred = "20", // На отделении
                Discharged = "294", // Выбыло
                Death = "4", // Умерло
            },
            new HospitalDep {
                ID = 4,
                Name = "Кардиологическое",
                Received = "174", // Поступило
                //FreeBeds = "4", // Свободных мест
                Transferred = "12", // На отделении
                Discharged = "162", // Выбыло
                Death = "44", // Умерло
            }
        };

        public static List<KassaDay> KassaMonth()
        {
            var date = DateTime.Today;
            var res = new List<KassaDay>();
            while (date > DateTime.Now.AddDays(-31))
            {
                
                var cachRand = new Random(date.GetHashCode());
                var i = cachRand.Next(5, 500);
                var cach = new Random(i).NextDouble() * 500;
                res.Add(new KassaDay() {Date = date, Cach = cach/*, Oms = cach.Next(5, 500), Dms = cach.Next(5, 500)*/ });
                date = date.AddDays(-1);
            }
            return res;
        }
    }
}