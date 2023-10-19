using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTickets
{
    public class ScheduleValidation
    {
        public static bool ExecuteValidateSchedule(List<Schedule> lSchedule)
        {
            bool ValidSchedule = default;
            List<int> noValidSchedule = new List<int>();
            lSchedule.ForEach(itemSchedule => 
            {
                int dataNovalidSchedule = default;
                bool IsValidatePeriodDaySchedule = default;

                int valueMinDays = 60;
                int valueMaxDays = 730;

                IsValidatePeriodDaySchedule = ValidatePeriodDaySchedule(itemSchedule, valueMinDays, valueMaxDays);

                if (!IsValidatePeriodDaySchedule)
                {
                    dataNovalidSchedule = itemSchedule.Secuential;
                    noValidSchedule.Add(dataNovalidSchedule);
                }

            });

            return ValidSchedule;
        }

        private static bool ValidatePeriodDaySchedule(Schedule dataSchedule , int minDays, int maxDays)
        {
            bool IsValidatePeriodDaySchedule  = default;

            int TotalDiffDay = int.Parse($"{(dataSchedule.DateEvent - DateTime.Now).TotalDays}");

            if(minDays > TotalDiffDay && TotalDiffDay < maxDays)
            {
                IsValidatePeriodDaySchedule = true;
            }
            else
            {
                IsValidatePeriodDaySchedule = false;
            }

            return IsValidatePeriodDaySchedule;
        }
    }
}
