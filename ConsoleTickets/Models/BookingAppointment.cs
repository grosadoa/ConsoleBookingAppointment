using ConsoleBookingAppointment.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBookingAppointment.Models
{
    public class BookingAppointment
    {
        public string DateAppointments { get; set; }
        public string Hour { get; set; }
        public Doctor? Doctor { get; set; }
        public Patient? Patient { get; set; }
        public MedicalRepresentative? MedicalRepresentative { get; set; } 
    }
}
