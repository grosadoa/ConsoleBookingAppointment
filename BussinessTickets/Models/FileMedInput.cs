using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessBookingAppointment.Models
{
    public class FileMedInput
    {
        public List<BookingAppointment> DataReservationsAppointmentsRegistered { get; set; } = new List<BookingAppointment>();
        public BookingAppointment DataReservationsAppointmentsNew { get; set; } = new BookingAppointment();
    }
}
