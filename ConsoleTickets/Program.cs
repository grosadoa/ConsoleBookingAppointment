using ConsoleTickets;
using System;
using System.Diagnostics.Tracing;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear(); // Limpiar la consola en cada iteración para actualizar la pantalla.

            Console.WriteLine("Welcome to the event management system.");
            Console.WriteLine("Menu Main Event");
            Console.WriteLine("1. Create Event");
            Console.WriteLine("2. Delete Event");
            Console.WriteLine("3. List Event");
            Console.WriteLine("4. Info Event");
            Console.WriteLine("5. Modified Event");
            Console.WriteLine("6. Quit");

            Console.Write("Select an option: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice))
            {
                EventsProcess eventsProcess = default;
                switch (choice)
                {
                    case 1:
                        eventsProcess = new EventsProcess();
                        eventsProcess.CreateEvent();
                        break;
                    case 2:
                        eventsProcess = new EventsProcess();
                        eventsProcess.DeleteEvent();
                        break;
                    case 3:
                        eventsProcess = new EventsProcess();
                        eventsProcess.ListEvent();
                        break;
                    case 4:
                        eventsProcess = new EventsProcess();
                        eventsProcess.InformationEvent();
                        return;
                    case 5:
                        eventsProcess = new EventsProcess();
                        eventsProcess.ModifiedEvent();
                        return;
                    case 6:
                        Console.WriteLine("Exiting the program.");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Enter a number from 1 to 5.");
                        break;
                }

                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Entrada no válida. Introduce un número del 1 al 6.");
                Console.Write("Presiona cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

    }
    
}
