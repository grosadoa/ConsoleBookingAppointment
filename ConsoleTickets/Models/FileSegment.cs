using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBookingAppointment.Models
{
    public class FileSegment
    {
        //public string Fecha { get; set; }
        public List<BookingAppointment> DataReservationsAppointmentsRegistered { get; set; } = new List<BookingAppointment>();
        public List<BookingAppointment> DataReservationsAppointmentsNew { get; set; } = new List<BookingAppointment>();
    }
}
