using BussinessBookingAppointment.Modelos;
using BussinessBookingAppointment.Models;
using BussinessBookingAppointment.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessBookingAppointment.Process
{
    public class ProcessBookingAppointmentValidate :IBookingAppointmentValidate
    {
        // HORARIO

        //El establecimiento opera de lunes a viernes => [1.1]
        //Las consultas médicas tienen los siguientes horarios: Lunes a jueves 8:00 a 19:00 Viernes 8:00 a 13:00 => [1.2]
        //El laboratorio clínico tiene el siguiente horario: Lunes a viernes 7:00 a 16:00 (OMITED)
        //Los días feriados no hay atención de ningún servicio.=> [1.3]
        //Solo se pueden registrar citas en el futuro.=> [1.4]
        //Los espacios son consecutivos, es decir 08:00, 08:20, etc => [1.5]
        public bool ValidateDayOperative(BookingAppointment dataToValidate) //[1.1]
        {
            bool result = true;

            DateTime appointmentDateValue = DateTime.Parse(dataToValidate.DateAppointment);

            if (appointmentDateValue.DayOfWeek == DayOfWeek.Saturday || appointmentDateValue.DayOfWeek == DayOfWeek.Sunday)
            {
                result = false;
            }

            return result;
        }

        public bool ValidateDayAndHourOperative(BookingAppointment dataToValidate) //[1.2]
        {
            bool result = true;

            DateTime appointmentDateValue = DateTime.Parse(dataToValidate.DateAppointment);
            TimeSpan appointmentHourValue = TimeSpan.Parse(dataToValidate.HourAppointment);

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

        public bool ValidateDayHoliday(BookingAppointment dataToValidate) //[1.3]
        {
            bool result = true;

            DateTime appointmentDateValue = DateTime.Parse(dataToValidate.DateAppointment);

            result = !RepositorySystem.datesHoliday.Any(valueItemHoliday => valueItemHoliday == appointmentDateValue);

            return result;
        }

        public bool ValidateDateFuture(BookingAppointment dataToValidate) //[1.4]
        {
            bool result = true;

            DateTime appointmentDateValue = DateTime.Parse(dataToValidate.DateAppointment);

            result = appointmentDateValue > DateTime.Now.Date ? true : false;

            return result;
        }
        public bool ValidateDateHourConsecutive(BookingAppointment dataToValidate, List<BookingAppointment> dataReservationsAppointmentsRegistered)//[1.5]
        {
            bool result = true;

            DateTime appointmentDateValue = DateTime.Parse(dataToValidate.DateAppointment);
            TimeSpan appointmentHourValue = TimeSpan.Parse(dataToValidate.HourAppointment);

            if (dataReservationsAppointmentsRegistered.Any(aa => DateTime.Parse(aa.DateAppointment) == appointmentDateValue &&
                TimeSpan.Parse(aa.HourAppointment) == appointmentHourValue &&
                aa.SpecialtyType == dataToValidate.Specialty))
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

        public bool ValidateDataPatient(Patient dataToValidate) //[2.1]
        {
            bool result = true;

            if (String.IsNullOrEmpty(dataToValidate.DocumentType) || String.IsNullOrEmpty(dataToValidate.IndentifierDocument) || String.IsNullOrEmpty(dataToValidate.NamePerson) ||
                String.IsNullOrEmpty(dataToValidate.Birthdate))
            {
                result = false;
            }

            return result;
        }

        public bool ValidateDataContact(string dataContact) //[2.2]
        {
            bool result = true;

            if (String.IsNullOrEmpty(dataContact))
            {
                result = false;
            }

            return result;
        }

        public bool ValidateNeedRepresentative(BookingAppointment dataToValidate) //[2.3]
        {
            bool result = true;

            if (dataToValidate.Patient.PatientType == Constants.TypePatiente_Minor && dataToValidate.MedicalRepresentative == null)
            {
                result = false;
            }

            return result;
        }

        public bool ValidateRepresentativeAdult(PatientRepresentative dataToValidate) //[2.4]
        {
            bool result = true;

            DateTime birthDate = DateTime.Parse(dataToValidate.Birthdate);

            if (!(DateTime.Now.Year - birthDate.Year >= 18))
            {
                result = false;
            }

            return result;
        }

        public bool ValidateExistsBooked(BookingAppointment dataToValidate, List<BookingAppointment> dataReservationsAppointmentsRegistered) //[2.5]
        {
            bool result = true;

            DateTime appointmentDateValue = DateTime.Parse(dataToValidate.DateAppointment);
            TimeSpan appointmentHourValue = TimeSpan.Parse(dataToValidate.HourAppointment);

            if (dataReservationsAppointmentsRegistered.Any(aa => aa.Patient.NamePerson == dataToValidate.Patient.NamePerson && DateTime.Parse(aa.DateAppointment) == appointmentDateValue && TimeSpan.Parse(aa.HourAppointment) == appointmentHourValue)) ;
            {
                result = false;
            }

            return result;
        }


        // CITAS


        //Los espacios para exámenes duran 20 minutos, por lo que la última cita se puede hacer 20 minutos antes de la hora de cierre. (OMITED)
        //Hay 5 profesionales disponibles.Dos generales y 3 especialistas. 
        //Las citas para especialistas deben agendarse con al menos 24h de anticipación. => [3.1]
        //Las citas de medicina general pueden agendarse el mismo día o ser asignadas al instante, sujeto a disponibilidad.
        //La atención de los generales está disponible la jornada completa.
        //Ningún profesional puede tener citas simultáneas => [3.2]

        public bool ValidateAdvanceBookingSpecialist(BookingAppointment dataToValidate) //[3.1]
        {
            bool result = true;

            if (dataToValidate.SpecialtyType == Constants.TypeSpecialist_General) return result = true;

            DateTime appointmentDateValue = DateTime.Parse(dataToValidate.DateAppointment);
            TimeSpan appointmentHourValue = TimeSpan.Parse(dataToValidate.HourAppointment);

            if (!(appointmentDateValue.Date >= DateTime.Now.AddDays(1).Date && appointmentHourValue >= DateTime.Now.AddDays(1).TimeOfDay))
            {
                result = false;
            }

            return result;
        }

        public bool ValidateBookedProfesionalDate(BookingAppointment dataToValidate, List<BookingAppointment> dataReservationsAppointmentsRegistered) //[3.2]
        {
            bool result = true;

            bool ExoneratedByTwoGeneral = true;
            DateTime appointmentDateValue = DateTime.Parse(dataToValidate.DateAppointment);
            TimeSpan appointmentHourValue = TimeSpan.Parse(dataToValidate.HourAppointment);

            if (dataToValidate.SpecialtyType == Constants.TypeSpecialist_Specialist)
            {
                ExoneratedByTwoGeneral = false;
            }
            else
            {
                int CounterSpecialistGeneral = dataReservationsAppointmentsRegistered.Count(cc => DateTime.Parse(cc.DateAppointment) == appointmentDateValue &&
                                                                        TimeSpan.Parse(cc.HourAppointment) == appointmentHourValue &&
                                                                        cc.SpecialtyType == Constants.TypeSpecialist_General);

                if (CounterSpecialistGeneral == 1)
                {
                    ExoneratedByTwoGeneral = true;
                }
                else
                {
                    ExoneratedByTwoGeneral = false;
                }
            }

            if (!ExoneratedByTwoGeneral)
                if (dataReservationsAppointmentsRegistered.Any(aa => DateTime.Parse(aa.DateAppointment) == appointmentDateValue && TimeSpan.Parse(aa.HourAppointment) == appointmentHourValue &&
                    aa.SpecialtyType == dataToValidate.Specialty))
                {
                    result = false;
                }

            return result;
        }
    }
}
