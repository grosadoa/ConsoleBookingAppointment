using BussinessBookingAppointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessBookingAppointment.Modelos
{
    public class Patient :Person
    {
        public string PatientType { get; set; }
    }
}
