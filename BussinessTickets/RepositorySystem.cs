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
        public static List<Events> lEvents { get; set; } = new List<Events>();
        public static List<PriceByTicket> lPriceByTicket { get; set; } = new List<PriceByTicket>();

        public static List<DateTime> datesHoliday { get; set; } = new List<DateTime> { DateTime.Parse("2023/11/20"),DateTime.Parse("2023/11/13") };

    }
}
