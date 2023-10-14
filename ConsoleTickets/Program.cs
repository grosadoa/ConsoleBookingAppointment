using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear(); // Limpiar la consola en cada iteración para actualizar la pantalla.

            Console.WriteLine("Menú Principal");
            Console.WriteLine("1. Opción 1");
            Console.WriteLine("2. Opción 2");
            Console.WriteLine("3. Opción 3");
            Console.WriteLine("4. Salir");

            Console.Write("Seleccione una opción: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Has seleccionado la Opción 1.");
                        // Realiza acciones relacionadas con la Opción 1.
                        break;
                    case 2:
                        Console.WriteLine("Has seleccionado la Opción 2.");
                        // Realiza acciones relacionadas con la Opción 2.
                        break;
                    case 3:
                        Console.WriteLine("Has seleccionado la Opción 3.");
                        // Realiza acciones relacionadas con la Opción 3.
                        break;
                    case 4:
                        Console.WriteLine("Saliendo del programa.");
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Introduce un número del 1 al 4.");
                        break;
                }

                Console.Write("Presiona cualquier tecla para continuar...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Entrada no válida. Introduce un número del 1 al 4.");
                Console.Write("Presiona cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
