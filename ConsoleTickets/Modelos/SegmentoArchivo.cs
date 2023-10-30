using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTickets.Models
{
    class SegmentoArchivo
    {
        public string Fecha { get; set; }
        public List<DatosPaciente> DatosPaciente { get; set; }
        public List<DatosPaciente> NuevasCitas { get; set; }
    }
}
