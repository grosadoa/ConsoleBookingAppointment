using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTickets
{
    public class EventsProcess
    {
        //public Events eDataEvent { get; set; }

        
        public void CreateEvent()
        {
            Console.WriteLine("You have selected the Create Event option.");
            Console.WriteLine();

            Events dataEvent = new Events();
            string inputDataUser = default;

            Console.WriteLine("Please enter the short name of the event: ");
            inputDataUser = Console.ReadLine();
            dataEvent.ShortNameEvent = inputDataUser;
            
            Console.WriteLine("Please enter the full name of the event: ");
            inputDataUser = Console.ReadLine();
            dataEvent.FullNameEvent = inputDataUser;

            Console.WriteLine("Please enter the date of the event: ");
            inputDataUser = Console.ReadLine();
            dataEvent.DateEvent = DateTime.Parse(inputDataUser);

            Console.WriteLine("Please enter the init hour of the event: ");
            inputDataUser = Console.ReadLine();
            dataEvent.HourInitEvent = TimeSpan.Parse(inputDataUser);

            Console.WriteLine("Please enter the end hour of the event: ");
            inputDataUser = Console.ReadLine();
            dataEvent.HourEndEvent = TimeSpan.Parse(inputDataUser);

            RepositorySystem.lEvents.Add(dataEvent);
            Console.WriteLine("successful created");

        }

        public void ListEvent()
        {
            Console.WriteLine("You have selected the Create List Event option.");
            Console.WriteLine();

            RepositorySystem.lEvents.ForEach(e => 
            {
                Console.WriteLine();
                Console.WriteLine($"Short Name Event: {e.ShortNameEvent}");
                Console.WriteLine($"Full Name Event: {e.FullNameEvent}");
                Console.WriteLine($"Date Event: {e.DateEvent}");
                Console.WriteLine($"Init Hour Event: {e.HourInitEvent}");
                Console.WriteLine($"End Hour Event: {e.HourEndEvent}");
                Console.WriteLine();
            });
        }

        public void InformationEvent()
        {
            Console.WriteLine("You have selected the Create Information Event option.");
            Console.WriteLine();

            Events dataEvent = new Events();
            string inputDataUser = default;

            Console.WriteLine("Please enter the short name of the event: ");
            inputDataUser = Console.ReadLine();
            dataEvent.ShortNameEvent = inputDataUser;

            dataEvent = RepositorySystem.lEvents.FirstOrDefault(ff => ff.ShortNameEvent == dataEvent.ShortNameEvent);

            Console.WriteLine();
            Console.WriteLine($"Short Name Event: {dataEvent.ShortNameEvent}");
            Console.WriteLine($"Full Name Event: {dataEvent.FullNameEvent}");
            Console.WriteLine($"Date Event: {dataEvent.DateEvent}");
            Console.WriteLine($"Init Hour Event: {dataEvent.HourInitEvent}");
            Console.WriteLine($"End Hour Event: {dataEvent.HourEndEvent}");
            Console.WriteLine();
        }

        internal void DeleteEvent()
        {
            Console.WriteLine("You have selected the Delete Information Event option.");
            Console.WriteLine();

            Events dataEvent = new Events();
            string inputDataUser = default;

            Console.WriteLine("Please enter the short name of the event: ");
            inputDataUser = Console.ReadLine();
            dataEvent.ShortNameEvent = inputDataUser;

            dataEvent = RepositorySystem.lEvents.FirstOrDefault(ff => ff.ShortNameEvent == dataEvent.ShortNameEvent);

            Console.WriteLine();
            Console.WriteLine($"Short Name Event: {dataEvent.ShortNameEvent}");
            Console.WriteLine($"Full Name Event: {dataEvent.FullNameEvent}");
            Console.WriteLine($"Date Event: {dataEvent.DateEvent}");
            Console.WriteLine($"Init Hour Event: {dataEvent.HourInitEvent}");
            Console.WriteLine($"End Hour Event: {dataEvent.HourEndEvent}");
            Console.WriteLine();

            Console.WriteLine("Are you sure you want to delete[Yes/No]: ");
            inputDataUser = Console.ReadLine();

            if(inputDataUser == "Yes")
            {
                int countDeleteEvent = default;
                countDeleteEvent = RepositorySystem.lEvents.RemoveAll(r => r.ShortNameEvent == dataEvent.ShortNameEvent);

                if(countDeleteEvent  != 0)
                {
                    Console.WriteLine("successful removal");
                }
            }
            
        }

        public void ModifiedEvent()
        {
            Console.WriteLine("You have selected the Modidied Event option.");

            Events dataEvent = new Events();
            string inputDataUser = default;

            Console.WriteLine("Please enter the short name of the event: ");
            inputDataUser = Console.ReadLine();
            dataEvent.ShortNameEvent = inputDataUser;

            dataEvent = RepositorySystem.lEvents.FirstOrDefault(ff => ff.ShortNameEvent == dataEvent.ShortNameEvent);

            Console.WriteLine();
            Console.WriteLine($"Short Name Event: {dataEvent.ShortNameEvent}");
            Console.WriteLine($"Full Name Event: {dataEvent.FullNameEvent}");
            Console.WriteLine($"Date Event: {dataEvent.DateEvent}");
            Console.WriteLine($"Init Hour Event: {dataEvent.HourInitEvent}");
            Console.WriteLine($"End Hour Event: {dataEvent.HourEndEvent}");
            Console.WriteLine();


            Console.WriteLine();
            //Console.WriteLine("Please enter the short name of the event: ");
            //inputDataUser = Console.ReadLine();
            //dataEvent.ShortNameEvent = inputDataUser;

            Console.WriteLine("Please enter the full name of the event: ");
            inputDataUser = Console.ReadLine();
            dataEvent.FullNameEvent = inputDataUser;

            Console.WriteLine("Please enter the date of the event: ");
            inputDataUser = Console.ReadLine();
            dataEvent.DateEvent = DateTime.Parse(inputDataUser);

            Console.WriteLine("Please enter the init hour of the event: ");
            inputDataUser = Console.ReadLine();
            dataEvent.HourInitEvent = TimeSpan.Parse(inputDataUser);

            Console.WriteLine("Please enter the end hour of the event: ");
            inputDataUser = Console.ReadLine();
            dataEvent.HourEndEvent = TimeSpan.Parse(inputDataUser);


            //RepositorySystem.lEvents.Add(dataEvent);

            Console.WriteLine("successful modified");
        }
    }
}
