using ConsoleBookingAppointment.Models;
using ConsoleBookingAppointment.Utils;

public class Program
{
    static void Main()
    {
        // Lectura de archivo
        string[] LineaArchivo = File.ReadAllLines(Constantes.RutaArchivo);

        SegmentoArchivo dataSegmentoArchivo = new SegmentoArchivo();
        List<DatosMedico> datosMedico = new List<DatosMedico>();
        List<DatosReservaCitas> datosReservasCitasRegistrado = new List<DatosReservaCitas>();
        List<DatosReservaCitas> datosReservasCitasNuevas = new List<DatosReservaCitas>();
        int SectionActualFile = Constantes.SeccionActualRegistrados;
        string FechaCitasActual = String.Empty;
        foreach (string linea in LineaArchivo)
        {
            if (linea.Contains(Constantes.IdentificadorSeccionNuevasCitas))
            {
                SectionActualFile = Constantes.SeccionActualNuevosCitas;
                continue;
            }

            string[] valorLinea = linea.Split('|');
            
            if (SectionActualFile == Constantes.SeccionActualRegistrados)
            {
                if (valorLinea.Length > 1)
                {
                    DatosReservaCitas datoCitaAnterior = new DatosReservaCitas
                    {
                        FechaCita = FechaCitasActual,
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

                    if (dataSegmentoArchivo != null)
                    {
                        datosReservasCitasRegistrado.Add(datoCitaAnterior);
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
                    FechaCitasActual = valorLinea[0];
                }
            }
            else
            {
                DatosReservaCitas datoCitaNueva = new DatosReservaCitas
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

                if (dataSegmentoArchivo != null)
                {
                    datosReservasCitasNuevas.Add(datoCitaNueva);
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
        dataSegmentoArchivo.DatosReservasCitasRegistrado = datosReservasCitasRegistrado;
        dataSegmentoArchivo.DatosReservasCitasNuevas = datosReservasCitasNuevas;

        ProgramHelpers.ImprimirListadoCitas(dataSegmentoArchivo.DatosReservasCitasRegistrado);
        ProgramHelpers.ImprimirCitasNuevas(dataSegmentoArchivo.DatosReservasCitasNuevas);
    }


    public void LecturaCitasAnteriores()
    {

    }


}


