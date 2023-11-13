using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessBookingAppointment.Utils
{
    public class Constants
    {

        //public static string FilePath = "\\med_input.txt";
        //public static string FilePath = "\\med_input_success.txt";
        //public static string FilePath = "\\med_input_error_dayoperative.txt";
        //public static string FilePath = "\\med_input_error_dayHourOperative_friday_after_1300.txt";
        //public static string FilePath = "\\med_input_error_dayHourOperative_monday_thurday_after_1900.txt";
        //public static string FilePath = "\\med_input_error_holiday.txt";
        //public static string FilePath = "\\med_input_error_dateFuture.txt";
        //public static string FilePath = "\\med_input_error_consecutiveDate_otherbooking.txt";
        //public static string FilePath = "\\med_input_error_consecutiveDate.txt";
        public static string FilePath = "\\med_input_success_consecutiveDate.txt";
        //public static string FilePath1 = "C:\\Users\\Rp3 Software\\Documents\\med_input.txt";
        public static string NewAppointmentsSectionIdentifier = "NUEVA CITA";
        public static int CurrentRegisteredSection = 1;
        public static int CurrentSectionNewAppointments = 2;
        public static string TypePatiente_Adult = "ADULTO";
        public static string TypePatiente_Minor = "PMENOR";
        public static string TypeSpecialist_General = "GENERAL";
        public static string TypeSpecialist_Specialist = "ESPECIALISTA";


        public class NameTypeTickets
        {
            public static string TicketVIP = "Ticket VIP";
            public static string TicketPiso = "Ticket Piso";
            public static string TicketTribuna = "Ticket Tribuna";
            public static string TicketGeneral = "Ticket General";
        }




    }
}
