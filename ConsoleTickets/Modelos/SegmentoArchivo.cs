using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBookingAppointment.Models
{
    public class SegmentoArchivo
    {
        //public string Fecha { get; set; }
        public List<DatosReservaCitas> DatosReservasCitasRegistrado { get; set; } = new List<DatosReservaCitas>();
        public List<DatosReservaCitas> DatosReservasCitasNuevas { get; set; } = new List<DatosReservaCitas>();
    }
}
