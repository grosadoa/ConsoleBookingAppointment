using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBookingAppointment.Utils
{
    public class Constantes
    {

        public static string RutaArchivo = "\\med_input.txt";
        public static string IdentificadorSeccionNuevasCitas = "NUEVA LINEA";
        public static int SeccionActualRegistrados = 1;
        public static int SeccionActualNuevosCitas = 2;

        public class NameTypeTickets
        {
            public static string TicketVIP = "Ticket VIP";
            public static string TicketPiso = "Ticket Piso";
            public static string TicketTribuna = "Ticket Tribuna";
            public static string TicketGeneral = "Ticket General";
        }




    }
}
