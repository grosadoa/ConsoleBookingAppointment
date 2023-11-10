using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBookingAppointment.Utils
{
    class UtilidadFechas
    {

        public static string calcularEdad(string fechaNacimiento)
        {
            string edad = "";
            try
            {
                DateTime fechaNacDate = DateTime.Now;
                fechaNacDate = DateTime.ParseExact(fechaNacimiento, "yyyy-MM-dd", null);
                DateTime fechaActual = DateTime.Now;
                TimeSpan diferecia = fechaActual - fechaNacDate;
                double dias = diferecia.TotalDays;
                double años = Math.Floor(dias / 365);
                edad = años + " años";
            }
            catch (Exception e)
            {
                
            }
            return edad;
        }
    }
}
