using BussinessBookingAppointment.Models;
using Microsoft.Win32;

internal static class PrinterHelpers
{
    public static void PrintListAppointments(List<BookingAppointment> listAppointments)
    {

        List<string> DateAppointments = listAppointments.GroupBy(g => g.DateAppointment).Select(ss => ss.Key).ToList();

        DateAppointments.ForEach(f => 
        {
            Console.WriteLine($" Fecha: {f}                                                                                                    |  Apoderado ");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------");
            Console.WriteLine("| Hora  |     Tipo     | Especialidad |        Nombre        | T.Documento |  Documento  |  Teléfono  | F. Nacimiento |        Nombre         | T.Documento |  Documento  | F. Nacimiento |");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------");

            foreach (var DataAppointments in listAppointments.Where(ww => ww.DateAppointment == f))
            {
                string rowCita = $"| {DataAppointments.HourAppointment} | {DataAppointments.SpecialtyType} | {DataAppointments.Specialty,-12} | {DataAppointments.Patient.NamePerson} | {DataAppointments.Patient.DocumentType,-11} | {DataAppointments.Patient.IndentifierDocument,-11} | {DataAppointments.PhoneContact,-10} | {DataAppointments.Patient.Birthdate,-13} |";


                if (DataAppointments.MedicalRepresentative != null)
                {
                    rowCita = rowCita + $" {DataAppointments.MedicalRepresentative.NamePerson}  | {DataAppointments.MedicalRepresentative.DocumentType,-11} | {DataAppointments.MedicalRepresentative.IndentifierDocument,-11} | {DataAppointments.MedicalRepresentative.Birthdate,-13} |";
                }
                Console.WriteLine(rowCita);
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------");
        });

        
    }


    public static void PrintNewAppointment(BookingAppointment listAppointments, bool isBookingValidate, List<string> messageObservation)
    {
        Console.WriteLine();
        Console.WriteLine($"Nueva Cita");
        

        Console.WriteLine();
        Console.WriteLine($"Fecha: {listAppointments.DateAppointment}");
        Console.WriteLine($"Hora: {listAppointments.HourAppointment}");
        Console.WriteLine($"Tipo: {listAppointments.SpecialtyType}");
        Console.WriteLine($"Especialidad: {listAppointments.Specialty}");
        Console.WriteLine($"Nombre: {listAppointments.Patient.NamePerson}");
        Console.WriteLine($"T. Documento: {listAppointments.Patient.DocumentType}");
        Console.WriteLine($"Documento: {listAppointments.Patient.IndentifierDocument}");
        Console.WriteLine($"Teléfono: {listAppointments.PhoneContact}");
        Console.WriteLine($"F. Nacimiento: {listAppointments.Patient.Birthdate}");

        Console.WriteLine();
        if (listAppointments.MedicalRepresentative != null)
        {
            Console.WriteLine("Datos del Apoderado:");
            Console.WriteLine($"Nombre: {listAppointments.MedicalRepresentative.NamePerson}");
            Console.WriteLine($"Tipo Documento: {listAppointments.MedicalRepresentative.DocumentType}");
            Console.WriteLine($"Documento: {listAppointments.MedicalRepresentative.IndentifierDocument}");
            Console.WriteLine($"F. Nacimiento: {listAppointments.MedicalRepresentative.Birthdate}");
        }

        Console.WriteLine();
        Console.WriteLine(isBookingValidate ? "Sucess...":"Error!");

        if (!isBookingValidate)
        {
            messageObservation.ForEach(x => Console.WriteLine(x));
        }
        
    }

    public static void PrintListHoliday(List<DateTime> datesHoliday)
    {
        Console.WriteLine();
        Console.WriteLine($"Feriados Registrados");

        datesHoliday.ForEach(ff => 
        { 
            Console.WriteLine($"Fecha: {ff.ToShortDateString()}");
        });
        Console.WriteLine();
    }
}