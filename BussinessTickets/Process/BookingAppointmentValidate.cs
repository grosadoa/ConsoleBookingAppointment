using BussinessBookingAppointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessBookingAppointment.Process
{
    public class BookingAppointmentValidate
    {
        public static bool ExecuteBookingAppointmentValidate(BookingAppointment dataToValidate, List<BookingAppointment> dataReservationsAppointmentsRegistered, List<string> messageObservation)
        {
            bool result = true;

            bool resultValidateDayOperative = ValidateDayOperative(dataToValidate);

            if (!resultValidateDayOperative) 
            {
                messageObservation.Add("El establecimiento opera de lunes a viernes.");
                result = false;
            }
            
            bool resultValidateDayAndHourOperative = ValidateDayAndHourOperative(dataToValidate);

            if (!resultValidateDayAndHourOperative) 
            {
                messageObservation.Add("Las consultas médicas tienen los siguientes horarios: Lunes a jueves 8:00 a 19:00 Viernes 8:00 a 13:00.");
                result = false;
            }

            return result;
        }

        // HORARIO

        //El establecimiento opera de lunes a viernes => [1.1]
        //Las consultas médicas tienen los siguientes horarios: Lunes a jueves 8:00 a 19:00 Viernes 8:00 a 13:00 => [1.2]
        //El laboratorio clínico tiene el siguiente horario: Lunes a viernes 7:00 a 16:00
        //Los días feriados no hay atención de ningún servicio.
        //Solo se pueden registrar citas en el futuro.
        //Los espacios son consecutivos, es decir 08:00, 08:20, etc


        private static bool ValidateDayOperative(BookingAppointment dataToValidate) //[1.1]
        {
            bool result = true;

            DateTime appointmentDateValue = DateTime.Parse(dataToValidate.DateAppointment);

            if(appointmentDateValue.DayOfWeek == DayOfWeek.Saturday || appointmentDateValue.DayOfWeek == DayOfWeek.Sunday)
            {
                result = false;
            }

            return result;
        }

        private static bool ValidateDayAndHourOperative(BookingAppointment dataToValidate) //[1.2]
        {
            bool result = true;

            DateTime appointmentDateValue = DateTime.Parse(dataToValidate.DateAppointment);

            if (appointmentDateValue.DayOfWeek == DayOfWeek.Saturday || appointmentDateValue.DayOfWeek == DayOfWeek.Sunday)
            {
                result = false;
            }

            return result;
        }



        // PACIENTE

        // CITAS
    }
}
