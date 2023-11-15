using BussinessBookingAppointment.Modelos;
using BussinessBookingAppointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessBookingAppointment.Process
{
    public interface IBookingAppointmentValidate
    {
        public bool ValidateDayOperative(BookingAppointment dataToValidate);
        public bool ValidateDayAndHourOperative(BookingAppointment dataToValidate);
        public bool ValidateDayHoliday(BookingAppointment dataToValidate);
        public bool ValidateDateFuture(BookingAppointment dataToValidate);
        public bool ValidateDateHourConsecutive(BookingAppointment dataToValidate, List<BookingAppointment> dataReservationsAppointmentsRegistered);
        public bool ValidateDataPatient(Patient dataToValidate);
        public bool ValidateDataContact(string dataContact);
        public bool ValidateNeedRepresentative(BookingAppointment dataToValidate);
        public bool ValidateRepresentativeAdult(PatientRepresentative dataToValidate);
        public bool ValidateExistsBooked(BookingAppointment dataToValidate, List<BookingAppointment> dataReservationsAppointmentsRegistered);
        public bool ValidateAdvanceBookingSpecialist(BookingAppointment dataToValidate);
        public bool ValidateBookedProfesionalDate(BookingAppointment dataToValidate, List<BookingAppointment> dataReservationsAppointmentsRegistered);
    }
}
