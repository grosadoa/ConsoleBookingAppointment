using BussinessBookingAppointment.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessBookingAppointment.Models
{
    public class BookingAppointment
    {
        public string DateAppointment { get; set; }
        public string HourAppointment { get; set; }
        public string SpecialtyType { get; set; }
        public string Specialty { get; set; }
        public Patient? Patient { get; set; }
        public MedicalRepresentative? MedicalRepresentative { get; set; } 
    }
}
