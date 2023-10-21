using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTickets
{
    public class ScheduleProcess
    {
        public static void ManageScheduleMenu( ref List<Schedule> lSchedule, string NameEvent)
        {
            bool TryMenuSchedule = default;
            do
            {
                TryMenuSchedule = true;
                Console.WriteLine("1. Create Schedule");
                Console.WriteLine("2. List Schedule");
                Console.WriteLine("3. Modified Schedule");
                Console.WriteLine("4. Delete Schedule");
                Console.WriteLine("5. Continue...");

                Console.Write("Select an option: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice))
                {
                    ScheduleProcess scheduleProcess = default;
                    switch (choice)
                    {
                        case 1:
                            CreateSchedule(ref lSchedule, NameEvent);
                            break;
                        case 2:
                            //scheduleProcess = new ScheduleProcess();
                            //scheduleProcess.ListSchedule(lSchedule, NameEvent);
                            ListSchedule(lSchedule, NameEvent);
                            break;
                        case 3:
                            //scheduleProcess = new ScheduleProcess();
                            //scheduleProcess.ModifiedSchedule(lSchedule, NameEvent);
                            break;
                        case 4:
                            //scheduleProcess = new ScheduleProcess();
                            //scheduleProcess.DeleteSchedule(lSchedule, NameEvent);
                            break;
                        case 5:
                            Console.WriteLine("Exiting the program.");
                            TryMenuSchedule = false;
                            break;

                        default:
                            break;
                    }
                }
            } while (TryMenuSchedule);
        }

        private static void CreateSchedule(ref List<Schedule> lSchedule, string NameEvent)
        {
            Console.WriteLine($"You have selected the Create Schedule option.({NameEvent})");
            Console.WriteLine();

            Schedule dataSchedule = new Schedule();
            string inputDataUser = default;

            Console.WriteLine("Please enter the Date schedule: ");
            inputDataUser = Console.ReadLine();
            dataSchedule.DateEvent = DateTime.Parse(inputDataUser);

            Console.WriteLine("Please enter the Hour Init: ");
            inputDataUser = Console.ReadLine();
            dataSchedule.HourInitEvent = TimeSpan.Parse(inputDataUser);
            
            Console.WriteLine("Please enter the Hour End: ");
            inputDataUser = Console.ReadLine();
            dataSchedule.HourEndEvent = TimeSpan.Parse(inputDataUser);

            dataSchedule.Secuential = lSchedule.Count + 1;

            lSchedule.Add(dataSchedule);
        }

        private static void DeleteSchedule(List<Schedule> lSchedule, string? shortNameEvent)
        {
            throw new NotImplementedException();
        }

        private static void ListSchedule(List<Schedule> lSchedule, string? shortNameEvent)
        {
            lSchedule.ForEach(l => 
            {
                Console.WriteLine();
                Console.WriteLine($"Secuential Schedule : {l.Secuential}");
                Console.WriteLine($"Date Schedule : {l.DateEvent}");
                Console.WriteLine($"Init Hour Schedule : {l.HourInitEvent}");
                Console.WriteLine($"End Hour Schedule : {l.HourEndEvent}");
                Console.WriteLine();
            });
        }

        private static void ModifiedSchedule(List<Schedule> lSchedule, string? shortNameEvent)
        {
            throw new NotImplementedException();
        }
    }
}
