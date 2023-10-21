using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTickets
{
    public class PriceByTicketProcess
    {
        public void CreatePriceByTicket(List<PriceByTicket> lPriceByTickets, string? shortNameEvent)
        {
            Console.WriteLine($"You have selected the Create Price Ticket Event {shortNameEvent}");
            Console.WriteLine();

            PriceByTicket dataPriceByTicket = new PriceByTicket();

            Console.WriteLine("0. General");
            Console.WriteLine("1. Tribuna");
            Console.WriteLine("2. Piso");
            Console.WriteLine("3. VIP");
            Console.WriteLine("Please enter the Type Ticket: ");
            
            string typeTicketInput = Console.ReadLine();

            if (Enum.TryParse<TypeTicket>(typeTicketInput, out TypeTicket typeTicket))
            {
                dataPriceByTicket.ETypeTicket = typeTicket;
            }
            else
            {
                Console.WriteLine("Invalid Type Ticket. Please enter a valid value.");
            }

            Console.WriteLine("Please enter the Price Ticket: ");
            if (int.TryParse(Console.ReadLine(), out int price))
            {
                dataPriceByTicket.PriceTicket = price;
            }
            else
            {
                Console.WriteLine("Invalid input for Price Ticket. Please enter a valid integer.");
                return;
            }

            if (PriceByTicketValidation.IsValidPrice(dataPriceByTicket, lPriceByTickets))
            {
                lPriceByTickets.Add(dataPriceByTicket);
                Console.WriteLine($"Price Ticket added successfully for event {shortNameEvent}.");
            }
            else
            {
                Console.WriteLine("Error: Invalid Price Ticket. It doesn't meet the required conditions.");
            }
        }

        public void DeletePriceByTicket(List<PriceByTicket> lPriceByTickets, string? shortNameEvent, TypeTicket typeToDelete)
        {
            var priceToDelete = lPriceByTickets.FirstOrDefault(price => price.ETypeTicket == typeToDelete);

            if (priceToDelete != null)
            {
                lPriceByTickets.Remove(priceToDelete);
                Console.WriteLine($"Price Ticket of type '{typeToDelete}' has been deleted for event {shortNameEvent}.");
            }
            else
            {
                Console.WriteLine($"Price Ticket of type '{typeToDelete}' was not found for event {shortNameEvent}.");
            }
        }

        public void ListPriceByTicket(List<PriceByTicket> lPriceByTickets, string? shortNameEvent)
        {
            Console.WriteLine("Price Tickets. Del evento " + shortNameEvent);
            Console.WriteLine();

            foreach (var e in lPriceByTickets)
            {
                Console.WriteLine();
                Console.WriteLine($"Type: {e.ETypeTicket}");
                Console.WriteLine($"Price: {e.PriceTicket}");
                Console.WriteLine();
            }
        }

        public void ModifiedPriceByTicket(List<PriceByTicket> lPriceByTickets, string? shortNameEvent, TypeTicket typeToModify, int newPrice)
        {
            var priceToModify = lPriceByTickets.FirstOrDefault(price => price.ETypeTicket == typeToModify);

            if (priceToModify != null)
            {
                priceToModify.PriceTicket = newPrice;
                Console.WriteLine($"Price Ticket of type '{typeToModify}' has been modified to {newPrice} for event {shortNameEvent}.");
            }
            else
            {
                Console.WriteLine($"Price Ticket of type '{typeToModify}' was not found for event {shortNameEvent}.");
            }
        }
    }
}
