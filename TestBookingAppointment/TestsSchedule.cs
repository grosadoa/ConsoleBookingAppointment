using BussinessBookingAppointment.Models;
using BussinessBookingAppointment.Process;

namespace TestBookingAppointment
{
    public class TestsSchedule
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestValidateDayOperative_SaturdayFalse()
        {

            ProcessBookingAppointmentValidate processBooking = new ProcessBookingAppointmentValidate();
            BookingAppointment bookingAppointment = new BookingAppointment();
            bookingAppointment.HourAppointment = "10:00";
            bookingAppointment.DateAppointment = "2023-11-18";
            bool isValidProcess = false;
            isValidProcess = processBooking.ValidateDayOperative(bookingAppointment);
            Assert.False(isValidProcess);
        }
    }
}