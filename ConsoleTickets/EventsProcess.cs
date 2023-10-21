using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTickets
{
    public class EventsProcess
    {
        
        public void CreateEvent()
        {
            Console.WriteLine("You have selected the Create Event option.");
            Console.WriteLine();

            Events dataEvent = new Events();

            dataEvent = CreateEventData(dataEvent);
            string inputDataUser = default;

            if (String.IsNullOrEmpty(dataEvent.ShortNameEvent) || String.IsNullOrEmpty(dataEvent.FullNameEvent))
            {
                Console.WriteLine();

                Console.WriteLine("You wish to modify or cancel[Yes/No]: ");
                inputDataUser = Console.ReadLine();
                if (inputDataUser == "Yes")
                {
                    dataEvent = CreateEventData(dataEvent);
                }
                else
                {
                    return;
                }
            }

            Console.WriteLine("Information to save: ");
            Console.WriteLine();
            Console.WriteLine($"Short Name Event: {dataEvent.ShortNameEvent}");
            Console.WriteLine($"Full Name Event: {dataEvent.FullNameEvent}");

            bool IsValidateSchedule = default;
            List<ScheduleGlobalValidate> scheduleGlobals = new List<ScheduleGlobalValidate>();
            foreach (Events item in RepositorySystem.lEvents)
            {
                List<ScheduleGlobalValidate> scheduleGlobalValidate = new List<ScheduleGlobalValidate>();

                scheduleGlobalValidate = item.lSchedule.Select(ss => new ScheduleGlobalValidate()
                {
                    ShortNameEvent = item.ShortNameEvent,
                    DateEvent = ss.DateEvent,
                    HourEndEvent = ss.HourEndEvent,
                    HourInitEvent = ss.HourInitEvent,
                    Secuential = ss.Secuential
                }).ToList();

                scheduleGlobals.AddRange(scheduleGlobalValidate);
            }

            IsValidateSchedule = ScheduleValidation.ExecuteValidateSchedule(dataEvent.ShortNameEvent,dataEvent.lSchedule, scheduleGlobals);

            if (IsValidateSchedule)
            {
                dataEvent.lSchedule.ForEach(f =>
                {
                    Console.WriteLine();
                    Console.WriteLine($"Secuential: {f.Secuential}");
                    Console.WriteLine($"Date Event: {f.DateEvent}");
                    Console.WriteLine($"Init Hour Event: {f.HourInitEvent}");
                    Console.WriteLine($"End Hour Event: {f.HourEndEvent}");
                });
            }
            else
            {
                Console.WriteLine();

                Console.WriteLine("You wish to modify or cancel[Yes/No]: ");
                inputDataUser = Console.ReadLine();

                if (inputDataUser == "Yes")
                {
                    dataEvent = CreateEventData(dataEvent);
                }
                else
                {
                    return;
                }
            }
            
            dataEvent.lPriceByTickets.ForEach(f => 
            {
                Console.WriteLine();
                Console.WriteLine($"Secuential: {f.Secuential}");
                Console.WriteLine($"Price Ticket: {f.PriceTicket}");
                Console.WriteLine($"TicketType Event: {f.ETypeTicket}");
            });

            Console.WriteLine();
            
            Console.WriteLine("Are you sure you want to create[Yes/No/Modify]: ");
            inputDataUser = Console.ReadLine();

            if (inputDataUser == "Yes")
            {
                RepositorySystem.lEvents.Add(dataEvent);
                Console.WriteLine("successful create");
            }
            else if(inputDataUser == "Modify")
            {
                dataEvent = CreateEventData(dataEvent);
                RepositorySystem.lEvents.Add(dataEvent);
            }
            else
            {
                Console.WriteLine("Process Create Canceled!");
            }

            Events CreateEventData(Events dataEvent)
            {
                string inputDataUser = default;
                bool QuestionContinueEvent = false;
                if (String.IsNullOrEmpty(dataEvent.ShortNameEvent))
                {
                    QuestionContinueEvent = true;
                }
                else
                {
                    Console.WriteLine("Should modified naming Info event?[Yes/No]: ");
                    inputDataUser = Console.ReadLine();

                    QuestionContinueEvent = inputDataUser == "Yes" ? true : false;
                    
                }

                if (QuestionContinueEvent)
                {
                    Console.WriteLine("Please enter the short name of the event: ");
                    inputDataUser = Console.ReadLine();
                    dataEvent.ShortNameEvent = inputDataUser;

                    Console.WriteLine("Please enter the full name of the event: ");
                    inputDataUser = Console.ReadLine();
                    dataEvent.FullNameEvent = inputDataUser;
                }

                List<Schedule> dataSchedule = dataEvent.lSchedule;
                ScheduleProcess.ManageScheduleMenu(ref dataSchedule, dataEvent.ShortNameEvent);

                PriceByTicketProcess priceByTicketProcess = new PriceByTicketProcess();
                bool TryMenuPriceByTicket = true;

                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Price by Ticket Menu");
                    Console.WriteLine("1. Create Price-Ticket");
                    Console.WriteLine("2. List Price-Ticket");
                    Console.WriteLine("3. Modify Price-Ticket");
                    Console.WriteLine("4. Delete Price-Ticket");
                    Console.WriteLine("5. Continue");

                    Console.Write("Select an option: ");
                    if (int.TryParse(Console.ReadLine(), out int choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                priceByTicketProcess.CreatePriceByTicket(dataEvent.lPriceByTickets, dataEvent.ShortNameEvent);
                                Console.WriteLine("Price Ticket created successfully.");
                                break;
                            case 2:
                                priceByTicketProcess.ListPriceByTicket(dataEvent.lPriceByTickets, dataEvent.ShortNameEvent);
                                break;
                            case 3:
                                //priceByTicketProcess.ModifiedPriceByTicket(dataEvent.lPriceByTickets, dataEvent.ShortNameEvent);
                                Console.WriteLine("Price Ticket modified successfully.");
                                break;
                            case 4:
                                //priceByTicketProcess.DeletePriceByTicket(dataEvent.lPriceByTickets, dataEvent.ShortNameEvent);
                                Console.WriteLine("Price Ticket deleted successfully.");
                                break;
                            case 5:
                                Console.WriteLine("Exiting the program.");
                                TryMenuPriceByTicket = false;
                                break;
                            default:
                                Console.WriteLine("Invalid choice. Please select a valid option.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                } while (TryMenuPriceByTicket);

                return dataEvent;
            } 

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

                e.lSchedule.ForEach(e2 => 
                {
                    Console.WriteLine();
                    Console.WriteLine($"Sencuential Schedule: {e2.Secuential}");
                    Console.WriteLine($"Date Schecule: {e2.DateEvent}");
                    Console.WriteLine($"Init Hour Schedule: {e2.HourInitEvent}");
                    Console.WriteLine($"End Hour Schedule: {e2.HourEndEvent}");
                });  
                
                e.lPriceByTickets.ForEach(e3 => 
                {
                    Console.WriteLine();
                    Console.WriteLine($"Sencuential Price By Ticket: {e3.Secuential}");
                    Console.WriteLine($"Price : {e3.PriceTicket}");

                    string nameTicket = default;

                    switch (e3.ETypeTicket)
                    {
                        case TypeTicket.General:
                            nameTicket = Constants.NameTypeTickets.TicketGeneral;
                            break;
                        case TypeTicket.Tribuna:
                            nameTicket = Constants.NameTypeTickets.TicketTribuna;
                            break;
                        case TypeTicket.Piso:
                            nameTicket = Constants.NameTypeTickets.TicketPiso;
                            break;
                        case TypeTicket.VIP:
                            nameTicket = Constants.NameTypeTickets.TicketVIP;
                            break;
                        default:
                            break;
                    }

                    Console.WriteLine($"Ticket: {nameTicket}");
                });
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
            //Console.WriteLine($"Date Event: {dataEvent.DateEvent}");
            //Console.WriteLine($"Init Hour Event: {dataEvent.HourInitEvent}");
            //Console.WriteLine($"End Hour Event: {dataEvent.HourEndEvent}");
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
            //Console.WriteLine($"Date Event: {dataEvent.DateEvent}");
            //Console.WriteLine($"Init Hour Event: {dataEvent.HourInitEvent}");
            //Console.WriteLine($"End Hour Event: {dataEvent.HourEndEvent}");
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
            //Console.WriteLine($"Date Event: {dataEvent.DateEvent}");
            //Console.WriteLine($"Init Hour Event: {dataEvent.HourInitEvent}");
            //Console.WriteLine($"End Hour Event: {dataEvent.HourEndEvent}");
            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine("Please enter the full name of the event: ");
            inputDataUser = Console.ReadLine();
            dataEvent.FullNameEvent = inputDataUser;

            //Console.WriteLine("Please enter the date of the event: ");
            //inputDataUser = Console.ReadLine();
            //dataEvent.DateEvent = DateTime.Parse(inputDataUser);

            //Console.WriteLine("Please enter the init hour of the event: ");
            //inputDataUser = Console.ReadLine();
            //dataEvent.HourInitEvent = TimeSpan.Parse(inputDataUser);

            //Console.WriteLine("Please enter the end hour of the event: ");
            //inputDataUser = Console.ReadLine();
            //dataEvent.HourEndEvent = TimeSpan.Parse(inputDataUser);


            //RepositorySystem.lEvents.Add(dataEvent);

            Console.WriteLine("successful modified");
        }
    }
}
