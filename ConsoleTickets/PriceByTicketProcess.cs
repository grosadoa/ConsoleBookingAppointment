using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTickets
{
    public class PriceByTicketProcess
    {
        public void CreatePriceByTicket(List<PriceByTicket> lPriceByTickets, string? shortNameEvent)
        {
            Console.WriteLine($"You have selected the Create Price Ticket option.({shortNameEvent})");
            Console.WriteLine();

            PriceByTicket dataPriceByTicket = new PriceByTicket();
            string inputDataUser = default;

            /*Console.WriteLine("Please enter the Type Ticket: ");
            inputDataUser = Console.ReadLine();
            dataPriceByTicket.ETypeTicket = inputDataUser;*/

            Console.WriteLine("Please enter the Price Ticket: ");
            inputDataUser = Console.ReadLine();
            dataPriceByTicket.PriceTicket  = int.Parse(s: inputDataUser);

            lPriceByTickets.Add(dataPriceByTicket);
        }

        public void DeletePriceByTicket(List<PriceByTicket> lPriceByTickets, string? shortNameEvent)
        {
            throw new NotImplementedException();
        }

        public void ListPriceByTicket(List<PriceByTicket> lPriceByTickets, string? shortNameEvent)
        {
            Console.WriteLine("Price Tickets.");
            Console.WriteLine();

            RepositorySystem.lPriceByTicket.ForEach(e =>
            {
                Console.WriteLine();
                Console.WriteLine($"Type: {e.ETypeTicket}");
                Console.WriteLine($"Price: {e.PriceTicket}");
                Console.WriteLine();
            });
        }

        public void ModifiedPriceByTicket(List<PriceByTicket> lPriceByTickets, string? shortNameEvent)
        {
            throw new NotImplementedException();
        }
    }
}
