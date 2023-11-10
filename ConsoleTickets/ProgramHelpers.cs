using ConsoleBookingAppointment.Models;
using Microsoft.Win32;

internal static class ProgramHelpers
{
    public static void ImprimirListadoCitas(List<DatosReservaCitas> listaCitas)
    {

        List<string> FechasCitas = listaCitas.GroupBy(g => g.FechaCita).Select(ss => ss.Key).ToList();

        FechasCitas.ForEach(f => 
        {
            Console.WriteLine($" Fecha: {f}                                                                                                               |  Apoderado ");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------");
            Console.WriteLine("| Hora  |     Tipo     | Especialidad |        Nombre        |   Edad   | T.Documento |  Documento  |  Teléfono  | F. Nacimiento |        Nombre         | T.Documento |  Documento  | F. Nacimiento |");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------");

            foreach (var datoCita in listaCitas.Where(ww => ww.FechaCita == f))
            {
                string rowCita = $"| {datoCita.Hora} | {datoCita.Tipo} | {datoCita.Especialidad,-12} | {datoCita.Nombre} | {datoCita.Edad,-8} | {datoCita.TipoDocumento,-11} | {datoCita.Documento,-11} | {datoCita.Telefono,-10} | {datoCita.FechaNacimiento,-13} |";

                if (datoCita.Apoderado != null)
                {
                    rowCita = rowCita + $" {datoCita.Apoderado.Nombre}  | {datoCita.Apoderado.TipoDocumento,-11} | {datoCita.Apoderado.Documento,-11} | {datoCita.Apoderado.FechaNacimiento,-13} |";
                }
                Console.WriteLine(rowCita);
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------");
        });

        
    }


    public static void ImprimirCitasNuevas(List<DatosReservaCitas> listaCitas)
    {
        Console.WriteLine();
        Console.WriteLine($"Nueva Cita");
        foreach (var nuevacita in listaCitas)
        {
            Console.WriteLine();
            Console.WriteLine($"Fecha: {nuevacita.Hora}");
            Console.WriteLine($"Hora: {nuevacita.Hora}");
            Console.WriteLine($"Tipo: {nuevacita.Tipo}");
            Console.WriteLine($"Especialidad: {nuevacita.Especialidad}");
            Console.WriteLine($"Nombre: {nuevacita.Nombre}");
            Console.WriteLine($"Edad: {nuevacita.Edad}");
            Console.WriteLine($"T. Documento: {nuevacita.TipoDocumento}");
            Console.WriteLine($"Documento: {nuevacita.Documento}");
            Console.WriteLine($"Teléfono: {nuevacita.Telefono}");
            Console.WriteLine($"F. Nacimiento: {nuevacita.FechaNacimiento}");
            
            Console.WriteLine();
            if (nuevacita.Apoderado != null)
            {
                Console.WriteLine("Datos del Apoderado:");
                Console.WriteLine($"Nombre: {nuevacita.Apoderado.Nombre}");
                Console.WriteLine($"Tipo Documento: {nuevacita.Apoderado.TipoDocumento}");
                Console.WriteLine($"Documento: {nuevacita.Apoderado.Documento}");
                Console.WriteLine($"F. Nacimiento: {nuevacita.Apoderado.FechaNacimiento}");
            }

        }

        Console.WriteLine();
    }

    
}