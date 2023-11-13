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

namespace BussinessBookingAppointment.Process
{
    public class BookingAppointmentValidate
    {
        public static bool ExecuteBookingAppointmentValidate(BookingAppointment dataToValidate, List<BookingAppointment> dataReservationsAppointmentsRegistered, List<string> messageObservation)
        {
            bool result = true;

            // HORARIO
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

            bool resultValidateDayHoliday = ValidateDayHoliday(dataToValidate);

            if (!resultValidateDayHoliday) 
            {
                messageObservation.Add("Los días feriados no hay atención de ningún servicio.");
                result = false;
            }
            
            bool resultValidateDateFuture = ValidateDateFuture(dataToValidate);

            if (!resultValidateDateFuture) 
            {
                messageObservation.Add("Solo se pueden registrar citas en el futuro.");
                result = false;
            }
            
            bool resultValidateDateHourConsecutive = ValidateDateHourConsecutive(dataToValidate, dataReservationsAppointmentsRegistered);

            if (!resultValidateDateHourConsecutive) 
            {
                messageObservation.Add("Los espacios son consecutivos, es decir 08:00, 08:20, etc.");
                result = false;
            }
            
            // PACIENTE

            bool resultValidateDataPatient = ValidateDataPatient(dataToValidate.Patient);

            if (!resultValidateDataPatient) 
            {
                messageObservation.Add("Se requiere tener identificación(cédula o pasaporte), nombres, apellidos y fecha de nacimiento.");
                result = false;
            }
            
            bool resultValidateDataContact = ValidateDataContact(dataToValidate.PhoneContact);

            if (!resultValidateDataContact) 
            {
                messageObservation.Add("Se debe registrar datos de contacto: número téléfono de contacto.");
                result = false;
            }
            
            bool resultValidateNeedRepresentative = ValidateNeedRepresentative(dataToValidate);

            if (!resultValidateNeedRepresentative) 
            {
                messageObservation.Add("Se debe registrar un adulto apoderado.");
                result = false;
            }
            
            bool resultValidateRepresentativeAdult = ValidateRepresentativeAdult(dataToValidate.MedicalRepresentative);

            if (!resultValidateRepresentativeAdult) 
            {
                messageObservation.Add("Los apoderados deben ser mayores de edad.");
                result = false;
            }
            
            bool resultValidateExistsBooked = ValidateExistsBooked(dataToValidate, dataReservationsAppointmentsRegistered);

            if (!resultValidateRepresentativeAdult) 
            {
                messageObservation.Add("Un paciente no puede tener citas simultáneas ni en el mismo servicio ni en distintos servicios.");
                result = false;
            }

            return result;
        }

        

        // HORARIO

        //El establecimiento opera de lunes a viernes => [1.1]
        //Las consultas médicas tienen los siguientes horarios: Lunes a jueves 8:00 a 19:00 Viernes 8:00 a 13:00 => [1.2]
        //El laboratorio clínico tiene el siguiente horario: Lunes a viernes 7:00 a 16:00 (OMITED)
        //Los días feriados no hay atención de ningún servicio.=> [1.3]
        //Solo se pueden registrar citas en el futuro.=> [1.4]
        //Los espacios son consecutivos, es decir 08:00, 08:20, etc => [1.5]


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
            TimeSpan appointmentHourValue = TimeSpan.Parse( dataToValidate.HourAppointment);

            switch (appointmentDateValue.DayOfWeek)
            {
                case DayOfWeek.Monday:
                case DayOfWeek.Tuesday:
                case DayOfWeek.Wednesday:
                case DayOfWeek.Thursday:
                    if (!(appointmentHourValue >= TimeSpan.Parse("08:00") && appointmentHourValue <= TimeSpan.Parse("19:00")))
                    {
                        result = false;
                    }
                    break;
                case DayOfWeek.Friday:

                    if (!(appointmentHourValue >= TimeSpan.Parse("08:00") && appointmentHourValue <= TimeSpan.Parse("13:00")))
                    {
                        result = false;
                    }
                    break;
                default:
                    break;
            }

            return result;
        }

        private static bool ValidateDayHoliday(BookingAppointment dataToValidate) //[1.3]
        {
            bool result = true;

            DateTime appointmentDateValue = DateTime.Parse(dataToValidate.DateAppointment);

            result = !RepositorySystem.datesHoliday.Any(valueItemHoliday => valueItemHoliday == appointmentDateValue);

            return result;
        }
        
        private static bool ValidateDateFuture(BookingAppointment dataToValidate) //[1.4]
        {
            bool result = true;

            DateTime appointmentDateValue = DateTime.Parse(dataToValidate.DateAppointment);

            result = appointmentDateValue > DateTime.Now.Date ? true : false;

            return result;
        }
        private static bool ValidateDateHourConsecutive(BookingAppointment dataToValidate, List<BookingAppointment> dataReservationsAppointmentsRegistered)//[1.5]
        {
            bool result = true;

            DateTime appointmentDateValue = DateTime.Parse(dataToValidate.DateAppointment);
            TimeSpan appointmentHourValue = TimeSpan.Parse(dataToValidate.HourAppointment);

            if(dataReservationsAppointmentsRegistered.Any(aa => DateTime.Parse(aa.DateAppointment) == appointmentDateValue && TimeSpan.Parse( aa.HourAppointment) == appointmentHourValue && aa.SpecialtyType == dataToValidate.Specialty))
            {
                result = false;
            }

            if (!(appointmentHourValue.TotalMinutes % 20 == 0))
            {
                result = false;
            }
            return result;
        }

        // PACIENTE

        //Se requiere tener identificación(cédula o pasaporte), nombres, apellidos, fecha de nacimiento => [2.1]
        //Se debe registrar datos de contacto: número téléfono de contacto, correo electrónico => [2.2]
        //Para el caso de menores de edad, se debe registrar un adulto apoderado con los mismos datos que un paciente y los datos de contacto serán los del apoderado en lugar de los datos del paciente => [2.3]
        //Los apoderados deben ser mayores de edad => [2.4]
        //Un paciente no puede tener citas simultáneas ni en el mismo servicio ni en distintos servicios => [2.5]

        private static bool ValidateDataPatient(Patient dataToValidate) //[2.1]
        {
            bool result = true;

            if (String.IsNullOrEmpty(dataToValidate.DocumentType) || String.IsNullOrEmpty(dataToValidate.IndentifierDocument) || String.IsNullOrEmpty(dataToValidate.NamePerson) || 
                String.IsNullOrEmpty(dataToValidate.Birthdate) )
            {
                result = false;
            }

            return result;
        }
        
        private static bool ValidateDataContact(string dataContact) //[2.2]
        {
            bool result = true;

            if (String.IsNullOrEmpty(dataContact) )
            {
                result = false;
            }

            return result;
        }
        
        private static bool ValidateNeedRepresentative(BookingAppointment dataToValidate) //[2.3]
        {
            bool result = true;

            if (dataToValidate.Patient.PatientType == Constants.TypePatiente_Minor && dataToValidate.MedicalRepresentative == null)
            {
                result = false;
            }

            return result;
        }
        
        private static bool ValidateRepresentativeAdult(PatientRepresentative dataToValidate) //[2.4]
        {
            bool result = true;

            DateTime birthDate = DateTime.Parse( dataToValidate.Birthdate);

            if( !(DateTime.Now.Year - birthDate.Year >= 18))
            {
                result = false;
            }

            return result;
        }
        
        private static bool ValidateExistsBooked(BookingAppointment dataToValidate, List<BookingAppointment> dataReservationsAppointmentsRegistered) //[2.5]
        {
            bool result = true;

            DateTime appointmentDateValue = DateTime.Parse(dataToValidate.DateAppointment);
            TimeSpan appointmentHourValue = TimeSpan.Parse(dataToValidate.HourAppointment);

            if (dataReservationsAppointmentsRegistered.Any(aa =>aa.Patient.NamePerson == dataToValidate.Patient.NamePerson && DateTime.Parse(aa.DateAppointment) == appointmentDateValue && TimeSpan.Parse(aa.HourAppointment) == appointmentHourValue));
            {
                result = false;
            }

            return result;
        }


        // CITAS
    }
}
