using BussinessTickets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTickets
{
    public class PriceByTicketValidation
    {

        public static bool IsValidPrice(PriceByTicket price, List<PriceByTicket> existingPrices)
        {

            var existType = existingPrices.FirstOrDefault(p => p.ETypeTicket == price.ETypeTicket);
            if (existType != null)
            {
                Console.WriteLine("Invalid choice. The chosen option already exists.");
                return false;
            }

            PriceByTicket generalPrice  = existingPrices.FirstOrDefault(p => p.ETypeTicket == TypeTicket.General);
            PriceByTicket tribunaPrice = existingPrices.FirstOrDefault(p => p.ETypeTicket == TypeTicket.Tribuna);
            PriceByTicket pisoPrice = existingPrices.FirstOrDefault(p => p.ETypeTicket == TypeTicket.Piso);
            PriceByTicket vipPrice = existingPrices.FirstOrDefault(p => p.ETypeTicket == TypeTicket.VIP);

            switch (price.ETypeTicket)
            {
                case TypeTicket.General:
                    var lowerPrice = existingPrices.FirstOrDefault(p => p.PriceTicket <= price.PriceTicket);
                    if (lowerPrice != null)
                    {
                        Console.WriteLine("Invalid choice. The value of the ticket general cannot be less than those already entered");
                        return false;
                    }
                    return true;
                case TypeTicket.Tribuna:
                    if (generalPrice  != null && price.PriceTicket <= generalPrice .PriceTicket)
                    {
                        Console.WriteLine("Invalid choice. The value of the ticket Tribuna cannot be less than those already entered");
                        return false;
                    }
                    if (pisoPrice != null && price.PriceTicket >= pisoPrice.PriceTicket)
                    {
                        Console.WriteLine("Invalid choice. The value of the ticket Tribuna cannot be greater than Piso");
                        return false;
                    }
                    if (vipPrice != null && price.PriceTicket >= vipPrice.PriceTicket)
                    {
                        Console.WriteLine("Invalid choice. The value of the ticket Tribuna cannot be greater than VIP");
                        return false;
                    }
                    return true;
                case TypeTicket.Piso:
                    if (generalPrice  != null && price.PriceTicket <= generalPrice .PriceTicket)
                    {
                        Console.WriteLine("Invalid choice. The value of the ticket Piso cannot be less than those already entered");
                        return false;
                    }
                    if (tribunaPrice != null && price.PriceTicket <= tribunaPrice.PriceTicket)
                    {
                        Console.WriteLine("Invalid choice. The value of the ticket Piso cannot be less than those already entered");
                        return false;
                    }
                    if (vipPrice != null && price.PriceTicket >= vipPrice.PriceTicket)
                    {
                        Console.WriteLine("Invalid choice. The value of the ticket Piso cannot be greater than VIP");
                        return false;
                    }
                    return true;
                case TypeTicket.VIP:
                    var higherPrice = existingPrices.FirstOrDefault(p => p.PriceTicket >= price.PriceTicket);
                    if (higherPrice != null)
                    {
                        Console.WriteLine("Invalid choice. The value of the ticket general cannot be higher than those already entered");
                        return false;
                    }
                    return true;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    return false;
            }
        }
    }
}
