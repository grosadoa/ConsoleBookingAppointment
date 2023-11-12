using BussinessBookingAppointment.Models;
using Microsoft.Win32;

internal static class ProgramHelpers
{
    public static void PrintListAppointments(List<BookingAppointment> listAppointments)
    {

        List<string> DateAppointments = listAppointments.GroupBy(g => g.DateAppointment).Select(ss => ss.Key).ToList();

        DateAppointments.ForEach(f => 
        {
            Console.WriteLine($" Fecha: {f}                                                                                                    |  Apoderado ");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------");
            //Console.WriteLine("| Hora  |     Tipo     | Especialidad |        Nombre        |   Edad   | T.Documento |  Documento  |  Teléfono  | F. Nacimiento |        Nombre         | T.Documento |  Documento  | F. Nacimiento |");
            Console.WriteLine("| Hora  |     Tipo     | Especialidad |        Nombre        | T.Documento |  Documento  |  Teléfono  | F. Nacimiento |        Nombre         | T.Documento |  Documento  | F. Nacimiento |");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------");

            foreach (var DataAppointments in listAppointments.Where(ww => ww.DateAppointment == f))
            {
                //string rowCita = $"| {DataAppointments.HourAppointment} | {DataAppointments.Doctor.SpecialtyType} | {DataAppointments.Doctor.Specialty,-12} | {DataAppointments.Doctor.Name} | {DataAppointments.Patient.Age,-8} | {DataAppointments.Patient.DocumentType,-11} | {DataAppointments.Patient.IndentifierDocument,-11} | {DataAppointments.Patient.Phone,-10} | {DataAppointments.Patient.Birthdate,-13} |";
                //string rowCita = $"| {DataAppointments.HourAppointment} | {DataAppointments.SpecialtyType} | {DataAppointments.Specialty,-12} | {DataAppointments.Patient.NamePerson} | {null} | {DataAppointments.Patient.DocumentType,-11} | {DataAppointments.Patient.IndentifierDocument,-11} | {DataAppointments.Patient.Phone,-10} | {DataAppointments.Patient.Birthdate,-13} |";
                string rowCita = $"| {DataAppointments.HourAppointment} | {DataAppointments.SpecialtyType} | {DataAppointments.Specialty,-12} | {DataAppointments.Patient.NamePerson} | {DataAppointments.Patient.DocumentType,-11} | {DataAppointments.Patient.IndentifierDocument,-11} | {DataAppointments.Patient.Phone,-10} | {DataAppointments.Patient.Birthdate,-13} |";


                if (DataAppointments.MedicalRepresentative != null)
                {
                    //rowCita = rowCita + $" {DataAppointments.MedicalRepresentative.Name}  | {DataAppointments.MedicalRepresentative.DocumentType,-11} | {DataAppointments.MedicalRepresentative.Document,-11} | {DataAppointments.MedicalRepresentative.Birthdate,-13} |";
                    rowCita = rowCita + $" {DataAppointments.MedicalRepresentative.NamePerson}  | {DataAppointments.MedicalRepresentative.DocumentType,-11} | {DataAppointments.MedicalRepresentative.IndentifierDocument,-11} | {DataAppointments.MedicalRepresentative.Birthdate,-13} |";
                }
                Console.WriteLine(rowCita);
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------");
        });

        
    }


    public static void PrintNewAppointment(List<BookingAppointment> listAppointments)
    {
        Console.WriteLine();
        Console.WriteLine($"Nueva Cita");
        foreach (var Appointment in listAppointments)
        {
            Console.WriteLine();
            Console.WriteLine($"Fecha: {Appointment.DateAppointment}");
            Console.WriteLine($"Hora: {Appointment.HourAppointment}");
            Console.WriteLine($"Tipo: {Appointment.SpecialtyType}");
            Console.WriteLine($"Especialidad: {Appointment.Specialty}");
            Console.WriteLine($"Nombre: {Appointment.Patient.NamePerson}");
            //Console.WriteLine($"Edad: {Appointment.Patient.Age}");
            Console.WriteLine($"T. Documento: {Appointment.Patient.DocumentType}");
            Console.WriteLine($"Documento: {Appointment.Patient.IndentifierDocument}");
            Console.WriteLine($"Teléfono: {Appointment.Patient.Phone}");
            Console.WriteLine($"F. Nacimiento: {Appointment.Patient.Birthdate}");
            
            Console.WriteLine();
            if (Appointment.MedicalRepresentative != null)
            {
                Console.WriteLine("Datos del Apoderado:");
                Console.WriteLine($"Nombre: {Appointment.MedicalRepresentative.NamePerson}");
                Console.WriteLine($"Tipo Documento: {Appointment.MedicalRepresentative.DocumentType}");
                Console.WriteLine($"Documento: {Appointment.MedicalRepresentative.IndentifierDocument}");
                Console.WriteLine($"F. Nacimiento: {Appointment.MedicalRepresentative.Birthdate}");
            }

        }

        Console.WriteLine();
    }

    
}