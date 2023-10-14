using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTickets
{
    public class ScheduleProcess
    {
        public void CreateSchedule(List<Schedule> lSchedule, string NameEvent)
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

            lSchedule.Add(dataSchedule);
        }

        public void DeleteSchedule(List<Schedule> lSchedule, string? shortNameEvent)
        {
            throw new NotImplementedException();
        }

        public void ListSchedule(List<Schedule> lSchedule, string? shortNameEvent)
        {
            throw new NotImplementedException();
        }

        public void ModifiedSchedule(List<Schedule> lSchedule, string? shortNameEvent)
        {
            throw new NotImplementedException();
        }
    }
}
