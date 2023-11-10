﻿using ConsoleBookingAppointment.Models;
using Microsoft.Win32;

internal static class ProgramHelpers
{
    public static void PrintListAppointments(List<BookingAppointment> listAppointments)
    {

        List<string> DateAppointments = listAppointments.GroupBy(g => g.DateAppointments).Select(ss => ss.Key).ToList();

        DateAppointments.ForEach(f => 
        {
            Console.WriteLine($" Fecha: {f}                                                                                                               |  Apoderado ");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------");
            Console.WriteLine("| Hora  |     Tipo     | Especialidad |        Nombre        |   Edad   | T.Documento |  Documento  |  Teléfono  | F. Nacimiento |        Nombre         | T.Documento |  Documento  | F. Nacimiento |");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------");

            foreach (var DataAppointments in listAppointments.Where(ww => ww.DateAppointments == f))
            {
                string rowCita = $"| {DataAppointments.Hour} | {DataAppointments.Doctor.SpecialtyType} | {DataAppointments.Doctor.Specialty,-12} | {DataAppointments.Doctor.Name} | {DataAppointments.Patient.Age,-8} | {DataAppointments.Patient.DocumentType,-11} | {DataAppointments.Patient.Document,-11} | {DataAppointments.Patient.Phone,-10} | {DataAppointments.Patient.Birthdate,-13} |";

                if (DataAppointments.MedicalRepresentative != null)
                {
                    rowCita = rowCita + $" {DataAppointments.MedicalRepresentative.Name}  | {DataAppointments.MedicalRepresentative.DocumentType,-11} | {DataAppointments.MedicalRepresentative.Document,-11} | {DataAppointments.MedicalRepresentative.Birthdate,-13} |";
                }
                Console.WriteLine(rowCita);
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------");
        });

        
    }


    public static void PrintNewAppointment(List<BookingAppointment> listAppointments)
    {
        Console.WriteLine();
        Console.WriteLine($"Nueva Cita");
        foreach (var Appointment in listAppointments)
        {
            Console.WriteLine();
            Console.WriteLine($"Fecha: {Appointment.DateAppointments}");
            Console.WriteLine($"Hora: {Appointment.Hour}");
            Console.WriteLine($"Tipo: {Appointment.Doctor.SpecialtyType}");
            Console.WriteLine($"Especialidad: {Appointment.Doctor.Specialty}");
            Console.WriteLine($"Nombre: {Appointment.Doctor.Name}");
            Console.WriteLine($"Edad: {Appointment.Patient.Age}");
            Console.WriteLine($"T. Documento: {Appointment.Patient.DocumentType}");
            Console.WriteLine($"Documento: {Appointment.Patient.Document}");
            Console.WriteLine($"Teléfono: {Appointment.Patient.Phone}");
            Console.WriteLine($"F. Nacimiento: {Appointment.Patient.Birthdate}");
            
            Console.WriteLine();
            if (Appointment.MedicalRepresentative != null)
            {
                Console.WriteLine("Datos del Apoderado:");
                Console.WriteLine($"Nombre: {Appointment.MedicalRepresentative.Name}");
                Console.WriteLine($"Tipo Documento: {Appointment.MedicalRepresentative.DocumentType}");
                Console.WriteLine($"Documento: {Appointment.MedicalRepresentative.Document}");
                Console.WriteLine($"F. Nacimiento: {Appointment.MedicalRepresentative.Birthdate}");
            }

        }

        Console.WriteLine();
    }

    
}