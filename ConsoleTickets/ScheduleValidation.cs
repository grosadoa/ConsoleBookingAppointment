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

            List<ScheduleValidate> noValidSchedulePeriodoDays = new List<ScheduleValidate>();
            lSchedule.ForEach(itemSchedule => 
            {
                ScheduleValidate scheduleValidate = new ScheduleValidate();
                scheduleValidate.InfoSchedule = itemSchedule;
                bool IsValidateSchedule = default;

                int valueMinDays = 60;
                int valueMaxDays = 730;

                //[statement] Solo se pueden colocar eventos desde 60 días posteriores hasta 2 años.
                IsValidateSchedule = ValidatePeriodDaySchedule(itemSchedule, valueMinDays, valueMaxDays);
                scheduleValidate.IsValidPeriodDays = IsValidateSchedule;

                //[statement] Cada evento puede durar un máximo de 4 horas
                int valueMaxHour = 4;
                IsValidateSchedule = ValidateTimeHourSchedule(itemSchedule, valueMaxHour);
                scheduleValidate.IsValidPeriodDays = IsValidateSchedule;

                
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

        
        private static bool ValidateTimeHourSchedule(Schedule dataSchedule, int maxHourSchedule)
        {
            bool IsValidateTimeHour = default;

            int TotalDiffHour = int.Parse($"{(dataSchedule.HourEndEvent - dataSchedule.HourInitEvent).TotalHours}");

            if (maxHourSchedule > TotalDiffHour )
            {
                IsValidateTimeHour = true;
            }
            else
            {
                IsValidateTimeHour = false;
            }

            return IsValidateTimeHour;
        }
    }
}
