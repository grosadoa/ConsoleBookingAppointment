using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTickets.Models
{
    class DatosApoderado
    {
        public string Tipo { get; set; }
        public string Nombre { get; set; }
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
        public string FechaNacimiento { get; set; }
    }
}
