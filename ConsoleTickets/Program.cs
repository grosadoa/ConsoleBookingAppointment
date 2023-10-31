using ConsoleTickets.Models;
using ConsoleTickets.Utils;

public class Program
{
    static void Main()
    {
        string[] LineaArchivo = File.ReadAllLines(Constantes.RutaArchivo);
        List<SegmentoArchivo> listaSegmentoArchivo = new List<SegmentoArchivo>();
        SegmentoArchivo segmentoArchivoActual = null;
        List<DatosMedico> datosMedico = new List<DatosMedico>();
        foreach (string linea in LineaArchivo)
        {

            string[] valorLinea = linea.Split('|');
            if (valorLinea.Length >= 9)
            {
                if (valorLinea[4].Trim() == "ADULTO" || valorLinea[4].Trim() == "PMENOR")
                {
                    DatosPaciente datoCitaAnterior = new DatosPaciente
                    {
                        Hora = valorLinea[0],
                        Tipo = valorLinea[1],
                        Especialidad = valorLinea[2],
                        Nombre = valorLinea[3],
                        TipoDocumento = valorLinea[5],
                        Documento = valorLinea[6],
                        Telefono = valorLinea[7],
                        FechaNacimiento = valorLinea[8],
                        Edad = ""
                    };

                    datoCitaAnterior.Edad = UtilidadFechas.calcularEdad(valorLinea[8]);


                    if (valorLinea[4].Trim() == "PMENOR" && valorLinea.Length >= 13)
                    {
                        datoCitaAnterior.Apoderado = new DatosApoderado
                        {
                            Tipo = valorLinea[9],
                            Nombre = valorLinea[10],
                            TipoDocumento = valorLinea[11],
                            Documento = valorLinea[12],
                            FechaNacimiento = valorLinea[13]
                        };
                    }

                    if (segmentoArchivoActual != null)
                    {
                        segmentoArchivoActual.DatosPaciente.Add(datoCitaAnterior);
                    }

                    DatosMedico datoMedico = new DatosMedico
                    {
                        Tipo = valorLinea[1],
                        Especialidad = valorLinea[2],
                        Nombre = valorLinea[3]
                    };

                    if (datoMedico != null)
                    {
                        bool existe = datosMedico.Any(objDatoMedico => objDatoMedico.Nombre.Equals(datoMedico.Nombre));

                        if (!existe)
                        {
                            datosMedico.Add(datoMedico);
                        }
                    }

                }
                else
                {
                    DatosPaciente datoCitaNueva = new DatosPaciente
                    {
                        FechaCita = valorLinea[0],
                        Hora = valorLinea[1],
                        Tipo = valorLinea[2],
                        Especialidad = valorLinea[3],
                        Nombre = valorLinea[4],
                        TipoDocumento = valorLinea[6],
                        Documento = valorLinea[7],
                        Telefono = valorLinea[8],
                        FechaNacimiento = valorLinea[9],
                        Edad = ""
                    };

                    datoCitaNueva.Edad = UtilidadFechas.calcularEdad(valorLinea[9]);

                    DatosMedico datoMedico = new DatosMedico
                    {
                        Tipo = valorLinea[1],
                        Especialidad = valorLinea[2],
                        Nombre = valorLinea[3]
                    };

                    if (valorLinea[5].Trim() == "PMENOR" && valorLinea.Length >= 13)
                    {
                        datoCitaNueva.Apoderado = new DatosApoderado
                        {
                            Tipo = valorLinea[10],
                            Nombre = valorLinea[11],
                            TipoDocumento = valorLinea[12],
                            Documento = valorLinea[13],
                            FechaNacimiento = valorLinea[14]
                        };
                    }

                    if (segmentoArchivoActual != null)
                    {
                        segmentoArchivoActual.NuevasCitas.Add(datoCitaNueva);
                    }

                    DatosMedico datoMedicoCitaNueva = new DatosMedico
                    {
                        Tipo = valorLinea[1],
                        Especialidad = valorLinea[2],
                        Nombre = valorLinea[3]
                    };

                    if (datoMedico != null)
                    {
                        bool existe = datosMedico.Any(objDatoMedico => objDatoMedico.Nombre.Equals(datoMedicoCitaNueva.Nombre));

                        if (!existe)
                        {
                            datosMedico.Add(datoMedico);
                        }
                    }

                }
            }
            else
            {
                segmentoArchivoActual = new SegmentoArchivo
                {
                    Fecha = valorLinea[0],
                    DatosPaciente = new List<DatosPaciente>(),
                    NuevasCitas = new List<DatosPaciente>()
                };
                listaSegmentoArchivo.Add(segmentoArchivoActual);
            }


        }


        foreach (var datoSeleccionado in listaSegmentoArchivo)
        {
            if (datoSeleccionado.DatosPaciente.Count > 0)
            {
                ProgramHelpers.ImprimirListadoCitas(datoSeleccionado);
            }
            if (datoSeleccionado.NuevasCitas.Count > 0)
            {
                ProgramHelpers.ImprimirCitasNuevas(datoSeleccionado.NuevasCitas);
            }
        }
    }


    public void LecturaCitasAnteriores(){
        
        
       }


}


