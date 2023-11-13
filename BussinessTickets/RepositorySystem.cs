using BussinessTickets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessBookingAppointment
{
    public class RepositorySystem
    {

        public static List<DateTime> datesHoliday { get; set; } = new List<DateTime> { DateTime.Parse("2023/11/20"),DateTime.Parse("2023/11/13") };

        public static List<string> PersonsSpecialist { get; set; } = new List<string> { "GENERAL_1","GENERAL_2","ESPECILISTA_1","ESPECILISTA_2","ESPECIALISTA_3" };

    }
}
