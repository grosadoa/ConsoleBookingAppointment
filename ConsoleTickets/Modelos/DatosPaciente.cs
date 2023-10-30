using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTickets.Models
{
    class DatosPaciente
    {
        public string FechaCita { get; set; }
        public string Hora { get; set; }
        public string Tipo { get; set; }
        public string Especialidad { get; set; }
        public string Nombre { get; set; }
        public string Edad { get; set; }
        private string tipoDocumento;
        public string TipoDocumento
        {
            get { return tipoDocumento; }
            set
            {
                if (value.Trim() == "C")
                {
                    tipoDocumento = "CEDULA";
                }
                else
                {
                    if (value.Trim() == "P")
                    {
                        tipoDocumento = "PASAPORTE";
                    }
                    else
                    {
                        tipoDocumento = value;
                    }
                }
            }
        }
        public string Documento { get; set; }
        public string Telefono { get; set; }
        public string FechaNacimiento { get; set; }
        public DatosApoderado Apoderado { get; set; } // Para menores con apoderado
    }
}
