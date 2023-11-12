using ConsoleBookingAppointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBookingAppointment.Modelos
{
    public class Patient :Person
    {
        //public string Age { get; set; }
        //private string documentType;
        //public string DocumentType
        //{
        //    get { return documentType; }
        //    set
        //    {
        //        if (value.Trim() == "C")
        //        {
        //            documentType = "CEDULA";
        //        }
        //        else
        //        {
        //            if (value.Trim() == "P")
        //            {
        //                documentType = "PASAPORTE";
        //            }
        //            else
        //            {
        //                documentType = value;
        //            }
        //        }
        //    }
        //}
        //public string IndentifierDocument { get; set; }
        public string Phone { get; set; }
        //public string Birthdate { get; set; }
        public string PatientType { get; set; }
    }
}
