using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTickets
{
    public class ScheduleValidation
    {
        public static bool ExecuteValidateSchedule(string ShortNameEvent, List<Schedule> lSchedule, List<ScheduleGlobalValidate> scheduleGlobals)
        {
            bool ValidSchedule = default;

            List<ScheduleValidate> noValidSchedule = new List<ScheduleValidate>();
            int valueMinDays = 60;
            int valueMaxDays = 730;
            int valueMaxHour = 4;

            lSchedule.ForEach(itemSchedule => 
            {
                ScheduleValidate scheduleValidate = new ScheduleValidate();
                scheduleValidate.InfoSchedule = itemSchedule;
                bool IsValidateSchedule = default;

                //[statement] Solo se pueden colocar eventos desde 60 días posteriores hasta 2 años.
                IsValidateSchedule = ValidatePeriodDaySchedule(itemSchedule, valueMinDays, valueMaxDays);
                scheduleValidate.IsValidPeriodDays = IsValidateSchedule;

                //[statement] Cada evento puede durar un máximo de 4 horas
                IsValidateSchedule = ValidateTimeHourSchedule(itemSchedule, valueMaxHour);
                scheduleValidate.IsValidPeriodDays = IsValidateSchedule;

                //[statement] no se pueden tener más de dos eventos el mismo día (evaluando contra la misma programacion del evento)
                IsValidateSchedule = ValidateConcurrenceIntoDayScheduleEvent(itemSchedule, lSchedule);
                scheduleValidate.IsValidateConcurrenceIntoDay = IsValidateSchedule;

                //[statement] no se pueden tener más de dos eventos el mismo día (evaluando contra la programacion global de todos los eventos)
                IsValidateSchedule = ValidateConcurrenceIntoDayScheduleEventGlobal(itemSchedule, scheduleGlobals);
                scheduleValidate.IsValidateConcurrenceIntoDayGlobal = IsValidateSchedule;

                //[statement] No se pueden tener eventos simultáneos (evaluando contra la misma programacion del evento)
                IsValidateSchedule = ValidateConcurrenceIntoHourScheduleEvent(itemSchedule, lSchedule);
                scheduleValidate.IsValidateConcurrenceIntoHour = IsValidateSchedule;

                //[statement] No se pueden tener eventos simultáneos (evaluando contra la programacion global de todos los eventos)
                IsValidateSchedule = ValidateConcurrenceIntoHourScheduleEventGlobal(itemSchedule, scheduleGlobals);
                scheduleValidate.IsValidateConcurrenceIntoHourGlobal = IsValidateSchedule;

                
                if(!scheduleValidate.IsValidPeriodDays || !scheduleValidate.IsValidateTimeHour || !scheduleValidate.IsValidateConcurrenceIntoDay || 
                    !scheduleValidate.IsValidateConcurrenceIntoDayGlobal || !scheduleValidate.IsValidateConcurrenceIntoHour || !scheduleValidate.IsValidateConcurrenceIntoHourGlobal)
                {
                    noValidSchedule.Add(scheduleValidate);
                }

            });



            noValidSchedule.ForEach(itemSchedule =>
            {
                Console.WriteLine();
                Console.WriteLine($"{ShortNameEvent}\t{itemSchedule.InfoSchedule.DateEvent}\t{itemSchedule.InfoSchedule.HourInitEvent}\t{itemSchedule.InfoSchedule.HourEndEvent}");
                if (itemSchedule.IsValidPeriodDays)
                {
                    Console.WriteLine($"* Period Day is Invalid. Recomneded Date Event Between {valueMinDays} Days and {valueMaxDays} Days");
                }
                
                if (itemSchedule.IsValidateTimeHour)
                {
                    Console.WriteLine($"* Period Time is Invalid. Recomneded Hour Event Have max {valueMaxHour} Hour");
                }
                
                if (itemSchedule.IsValidateConcurrenceIntoDay)
                {
                    Console.WriteLine($"* Validate Date, In this event exists conflict Date. Recomneded update Date Differente {itemSchedule.InfoSchedule.DateEvent.ToShortDateString()}");
                }
                
                if (itemSchedule.IsValidateConcurrenceIntoDayGlobal)
                {
                    Console.WriteLine($"* Validate Date, In other event exists conflict Date. Recomneded update Date Differente {itemSchedule.InfoSchedule.DateEvent.ToShortDateString()} ");
                }
                
                if (itemSchedule.IsValidateConcurrenceIntoHour)
                {
                    Console.WriteLine($"* Validate Date and Hour, In this event exists conflict Date. Recomneded update Date and Hour Differente {itemSchedule.InfoSchedule.DateEvent.ToShortDateString()} " +
                        $"- Hour ({itemSchedule.InfoSchedule.HourInitEvent}-{itemSchedule.InfoSchedule.HourEndEvent})");
                }
                
                if (itemSchedule.IsValidateConcurrenceIntoHourGlobal)
                {
                    Console.WriteLine($"* Validate Date and Hour, In other event exists conflict Date. Recomneded update Date and Hour Differente {itemSchedule.InfoSchedule.DateEvent.ToShortDateString()} " +
                        $"- Hour ({itemSchedule.InfoSchedule.HourInitEvent}-{itemSchedule.InfoSchedule.HourEndEvent})");
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

        private static bool ValidateConcurrenceIntoDayScheduleEvent(Schedule dataSchedule, List<Schedule> ldataSchedule)
        {
            bool IsValidateConcurrenceIntoDay = default;

            int countEventIntoDay = ldataSchedule.Count(aCount => aCount.DateEvent.ToShortDateString() == dataSchedule.DateEvent.ToShortDateString());

            if (countEventIntoDay > 1)
            {
                IsValidateConcurrenceIntoDay = true;
            }
            else
            {
                IsValidateConcurrenceIntoDay = false;
            }

            return IsValidateConcurrenceIntoDay;
        }

        private static bool ValidateConcurrenceIntoDayScheduleEventGlobal(Schedule dataSchedule, List<ScheduleGlobalValidate> ldataSchedule)
        {
            bool IsValidateConcurrenceIntoDayGlobal = default;

            int countEventIntoDay = ldataSchedule.Count(aCount => aCount.DateEvent.ToShortDateString() == dataSchedule.DateEvent.ToShortDateString());

            if (countEventIntoDay > 1)
            {
                IsValidateConcurrenceIntoDayGlobal = true;
            }
            else
            {
                IsValidateConcurrenceIntoDayGlobal = false;
            }

            return IsValidateConcurrenceIntoDayGlobal;
        }

        private static bool ValidateConcurrenceIntoHourScheduleEvent(Schedule dataSchedule, List<Schedule> ldataSchedule)
        {
            bool isValidateConcurrenceIntoHourScheduleEvent = default;

            isValidateConcurrenceIntoHourScheduleEvent = ldataSchedule.Any(aa => aa.DateEvent.ToShortDateString() == dataSchedule.DateEvent.ToShortDateString() &&
                dataSchedule.HourInitEvent >= aa.HourInitEvent  && dataSchedule.HourInitEvent <= dataSchedule.HourEndEvent);

            return isValidateConcurrenceIntoHourScheduleEvent;
        }
        
        private static bool ValidateConcurrenceIntoHourScheduleEventGlobal(Schedule dataSchedule, List<ScheduleGlobalValidate> ldataSchedule)
        {
            bool isValidateConcurrenceIntoHourScheduleEventGlobal = default;

            isValidateConcurrenceIntoHourScheduleEventGlobal = ldataSchedule.Any(aa => aa.DateEvent.ToShortDateString() == dataSchedule.DateEvent.ToShortDateString() &&
                dataSchedule.HourInitEvent >= aa.HourInitEvent  && dataSchedule.HourInitEvent <= dataSchedule.HourEndEvent);

            return isValidateConcurrenceIntoHourScheduleEventGlobal;
        }
    }
}
