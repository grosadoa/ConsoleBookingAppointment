using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTickets
{
    public class PriceByTicketValidation
    {
        
        public bool IsValidPrice(PriceByTicket price, List<PriceByTicket> existingPrices)
        {
            switch (price.ETypeTicket)
            {
                case TypeTicket.General:
                    return existingPrices.All(p => p.ETypeTicket != TypeTicket.General && p.PriceTicket <= price.PriceTicket);
                case TypeTicket.Tribuna:
                    return !existingPrices.Any(p => p.ETypeTicket == TypeTicket.General && p.PriceTicket >= price.PriceTicket) &&
                           existingPrices.All(p => p.ETypeTicket != TypeTicket.General && p.ETypeTicket != TypeTicket.Tribuna && p.PriceTicket <= price.PriceTicket);
                case TypeTicket.Piso:
                    return !existingPrices.Any(p => p.ETypeTicket == TypeTicket.General && p.PriceTicket >= price.PriceTicket) &&
                           !existingPrices.Any(p => p.ETypeTicket == TypeTicket.Tribuna && p.PriceTicket >= price.PriceTicket) &&
                           existingPrices.All(p => p.ETypeTicket != TypeTicket.General && p.ETypeTicket != TypeTicket.Tribuna && p.ETypeTicket != TypeTicket.Piso && p.PriceTicket <= price.PriceTicket);
                case TypeTicket.VIP:
                    return !existingPrices.Any(p => p.ETypeTicket == TypeTicket.General && p.PriceTicket >= price.PriceTicket) &&
                           !existingPrices.Any(p => p.ETypeTicket == TypeTicket.Tribuna && p.PriceTicket >= price.PriceTicket) &&
                           !existingPrices.Any(p => p.ETypeTicket == TypeTicket.Piso && p.PriceTicket >= price.PriceTicket) &&
                           existingPrices.All(p => p.ETypeTicket != TypeTicket.General && p.ETypeTicket != TypeTicket.Tribuna && p.ETypeTicket != TypeTicket.Piso && p.ETypeTicket != TypeTicket.VIP && p.PriceTicket <= price.PriceTicket);
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    return false;
            }
        }
    }
}
