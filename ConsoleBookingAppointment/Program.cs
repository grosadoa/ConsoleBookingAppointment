using BussinessBookingAppointment;
using BussinessBookingAppointment.Modelos;
using BussinessBookingAppointment.Models;
using BussinessBookingAppointment.Process;
using BussinessBookingAppointment.Utils;

public class Program
{
    static void Main()
    {
        FileMedInput dataFileMedInput = new FileMedInput();
        dataFileMedInput = ProcessReadFileToModel.ReadFileMedInput();

        BookingAppointment dataToValidate = dataFileMedInput.DataReservationsAppointmentsNew;
        List<string> messageObservation = new List<string>();
        bool isBookingValidate = false;
        isBookingValidate = BookingAppointmentValidate.ExecuteBookingAppointmentValidate(dataToValidate, dataFileMedInput.DataReservationsAppointmentsRegistered, messageObservation);

        if (isBookingValidate)
        {
            dataFileMedInput.DataReservationsAppointmentsRegistered.Add(dataToValidate);
        }

        PrinterHelpers.PrintListAppointments(dataFileMedInput.DataReservationsAppointmentsRegistered);
        PrinterHelpers.PrintListHoliday(RepositorySystem.datesHoliday);
        PrinterHelpers.PrintNewAppointment(dataFileMedInput.DataReservationsAppointmentsNew, isBookingValidate, messageObservation);
    }


}


