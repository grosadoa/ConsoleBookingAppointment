using BussinessBookingAppointment;
using BussinessBookingAppointment.Modelos;
using BussinessBookingAppointment.Models;
using BussinessBookingAppointment.Utils;

public class Program
{
    static void Main()
    {
        FileMedInput dataFileMedInput = new FileMedInput();
        dataFileMedInput = ProcessReadFileToModel.ReadFileMedInput();

        ProgramHelpers.PrintListAppointments(dataFileMedInput.DataReservationsAppointmentsRegistered);
        ProgramHelpers.PrintNewAppointment(dataFileMedInput.DataReservationsAppointmentsNew);
    }


    public void LecturaCitasAnteriores()
    {

    }


}


