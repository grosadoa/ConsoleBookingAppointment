﻿using System;
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

            Console.WriteLine("Information to save: ");
            Console.WriteLine();
            Console.WriteLine($"Short Name Event: {dataEvent.ShortNameEvent}");
            Console.WriteLine($"Full Name Event: {dataEvent.FullNameEvent}");
            
            dataEvent.lSchedule.ForEach(f => 
            {
                Console.WriteLine();
                Console.WriteLine($"Secuential: {f.Secuential}");
                Console.WriteLine($"Date Event: {f.DateEvent}");
                Console.WriteLine($"Init Hour Event: {f.HourInitEvent}");
                Console.WriteLine($"End Hour Event: {f.HourEndEvent}");
            });
            
            dataEvent.lPriceByTickets.ForEach(f => 
            {
                Console.WriteLine();
                Console.WriteLine($"Secuential: {f.Secuential}");
                Console.WriteLine($"Price Ticket: {f.PriceTicket}");
                Console.WriteLine($"TicketType Event: {f.ETypeTicket}");
            });

            Console.WriteLine();
            string inputDataUser = default;
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
                    Console.WriteLine("Should modified data event?[Yes/No]: ");
                    inputDataUser = Console.ReadLine();

                    if (inputDataUser == "Yes")
                    {
                        QuestionContinueEvent = true;
                        
                    }
                    else
                    {
                        QuestionContinueEvent = false;

                    }
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
                                scheduleProcess = new ScheduleProcess();
                                scheduleProcess.CreateSchedule(dataEvent.lSchedule, dataEvent.ShortNameEvent);
                                break;
                            case 2:
                                scheduleProcess = new ScheduleProcess();
                                scheduleProcess.ListSchedule(dataEvent.lSchedule, dataEvent.ShortNameEvent);
                                break;
                            case 3:
                                scheduleProcess = new ScheduleProcess();
                                scheduleProcess.ModifiedSchedule(dataEvent.lSchedule, dataEvent.ShortNameEvent);
                                break;
                            case 4:
                                scheduleProcess = new ScheduleProcess();
                                scheduleProcess.DeleteSchedule(dataEvent.lSchedule, dataEvent.ShortNameEvent);
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

                bool TryMenuPriceByTicket = default;
                do
                {
                    TryMenuPriceByTicket = true;
                    Console.WriteLine("1. Create Price-Ticket");
                    Console.WriteLine("2. List Price-Ticket");
                    Console.WriteLine("3. Modified Price-Ticket");
                    Console.WriteLine("4. Delete Price-Ticket");
                    Console.WriteLine("5. Continue...");

                    Console.Write("Select an option: ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out int choice))
                    {
                        PriceByTicketProcess priceByTicketProcess = default;
                        switch (choice)
                        {
                            case 1:
                                priceByTicketProcess = new PriceByTicketProcess();
                                priceByTicketProcess.CreatePriceByTicket(dataEvent.lPriceByTickets, dataEvent.ShortNameEvent);
                                break;
                            case 2:
                                priceByTicketProcess = new PriceByTicketProcess();
                                priceByTicketProcess.ListPriceByTicket(dataEvent.lPriceByTickets, dataEvent.ShortNameEvent);
                                break;
                            case 3:
                                priceByTicketProcess = new PriceByTicketProcess();
                                priceByTicketProcess.ModifiedPriceByTicket(dataEvent.lPriceByTickets, dataEvent.ShortNameEvent);
                                break;
                            case 4:
                                priceByTicketProcess = new PriceByTicketProcess();
                                priceByTicketProcess.DeletePriceByTicket(dataEvent.lPriceByTickets, dataEvent.ShortNameEvent);
                                break;
                            case 5:
                                Console.WriteLine("Exiting the program.");
                                TryMenuPriceByTicket = false;
                                break;

                            default:
                                break;
                        }
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
                //Console.WriteLine($"Date Event: {e.DateEvent}");
                //Console.WriteLine($"Init Hour Event: {e.HourInitEvent}");
                //Console.WriteLine($"End Hour Event: {e.HourEndEvent}");
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
