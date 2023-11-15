using BussinessBookingAppointment.Modelos;
using BussinessBookingAppointment.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessBookingAppointment.Utils;
using System.ComponentModel.Design;

namespace BussinessBookingAppointment.Process
{
    public class BookingAppointmentValidate 
    {
        public static bool ExecuteBookingAppointmentValidate(BookingAppointment dataToValidate, List<BookingAppointment> dataReservationsAppointmentsRegistered, List<string> messageObservation)
        {
            bool result = true;

            ProcessBookingAppointmentValidate processBooking = new ProcessBookingAppointmentValidate();
            // HORARIO
            bool resultValidateDayOperative = processBooking.ValidateDayOperative(dataToValidate);

            if (!resultValidateDayOperative) 
            {
                messageObservation.Add("El establecimiento opera de lunes a viernes.");
                result = false;
            }
            
            bool resultValidateDayAndHourOperative = processBooking.ValidateDayAndHourOperative(dataToValidate);

            if (!resultValidateDayAndHourOperative) 
            {
                messageObservation.Add("Las consultas médicas tienen los siguientes horarios: Lunes a jueves 8:00 a 19:00 Viernes 8:00 a 13:00.");
                result = false;
            }

            bool resultValidateDayHoliday = processBooking.ValidateDayHoliday(dataToValidate);

            if (!resultValidateDayHoliday) 
            {
                messageObservation.Add("Los días feriados no hay atención de ningún servicio.");
                result = false;
            }
            
            bool resultValidateDateFuture = processBooking.ValidateDateFuture(dataToValidate);

            if (!resultValidateDateFuture) 
            {
                messageObservation.Add("Solo se pueden registrar citas en el futuro.");
                result = false;
            }
            
            bool resultValidateDateHourConsecutive = processBooking.ValidateDateHourConsecutive(dataToValidate, dataReservationsAppointmentsRegistered);

            if (!resultValidateDateHourConsecutive) 
            {
                messageObservation.Add("Los espacios son consecutivos, es decir 08:00, 08:20, etc.");
                result = false;
            }
            
            // PACIENTE

            bool resultValidateDataPatient = processBooking.ValidateDataPatient(dataToValidate.Patient);

            if (!resultValidateDataPatient) 
            {
                messageObservation.Add("Se requiere tener identificación(cédula o pasaporte), nombres, apellidos y fecha de nacimiento.");
                result = false;
            }
            
            bool resultValidateDataContact = processBooking.ValidateDataContact(dataToValidate.PhoneContact);

            if (!resultValidateDataContact) 
            {
                messageObservation.Add("Se debe registrar datos de contacto: número téléfono de contacto.");
                result = false;
            }
            
            bool resultValidateNeedRepresentative = processBooking.ValidateNeedRepresentative(dataToValidate);

            if (!resultValidateNeedRepresentative) 
            {
                messageObservation.Add("Se debe registrar un adulto apoderado.");
                result = false;
            }
            
            bool resultValidateRepresentativeAdult = processBooking.ValidateRepresentativeAdult(dataToValidate.MedicalRepresentative);

            if (!resultValidateRepresentativeAdult) 
            {
                messageObservation.Add("Los apoderados deben ser mayores de edad.");
                result = false;
            }
            
            bool resultValidateExistsBooked = processBooking.ValidateExistsBooked(dataToValidate, dataReservationsAppointmentsRegistered);

            if (!resultValidateExistsBooked) 
            {
                messageObservation.Add("No puede tener citas simultáneas ni en el mismo servicio ni en distintos servicios.");
                result = false;
            }
            
            bool resultValidateAdvanceBookingSpecialist = processBooking.ValidateAdvanceBookingSpecialist(dataToValidate);

            if (!resultValidateAdvanceBookingSpecialist) 
            {
                messageObservation.Add("Las citas para especialistas deben agendarse con al menos 24h de anticipación.");
                result = false;
            }
            
            bool resultValidateBookedProfesionalDate = processBooking.ValidateBookedProfesionalDate(dataToValidate, dataReservationsAppointmentsRegistered);

            if (!resultValidateBookedProfesionalDate) 
            {
                messageObservation.Add("Ningún profesional puede tener citas simultáneas.");
                result = false;
            }

            return result;
        }
        
    }
}
