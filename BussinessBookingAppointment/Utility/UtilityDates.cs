using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessBookingAppointment.Utils
{
    class UtilityDates
    {

        public static string calculateAge(string birthdate)
        {
            string age = "";
            try
            {
                DateTime birthdateDate = DateTime.Now;
                birthdateDate = DateTime.ParseExact(birthdate, "yyyy-MM-dd", null);
                DateTime currentDate = DateTime.Now;
                TimeSpan difference = currentDate - birthdateDate;
                double days = difference.TotalDays;
                double years = Math.Floor(days / 365);
                age = years + " años";
            }
            catch (Exception e)
            {
                
            }
            return age;
        }
    }
}
