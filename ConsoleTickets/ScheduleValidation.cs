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
                //IsValidateSchedule = ValidatePeriodDaySchedule(itemSchedule, valueMinDays, valueMaxDays);
                IsValidateSchedule = itemSchedule.ValidatePeriodDaySchedule(itemSchedule, valueMinDays, valueMaxDays);
                scheduleValidate.IsValidPeriodDays = IsValidateSchedule;

                //[statement] Cada evento puede durar un máximo de 4 horas
                //IsValidateSchedule = ValidateTimeHourSchedule(itemSchedule, valueMaxHour);
                IsValidateSchedule = itemSchedule.ValidateTimeHourSchedule(itemSchedule, valueMaxHour);
                scheduleValidate.IsValidPeriodDays = IsValidateSchedule;

                //[statement] no se pueden tener más de dos eventos el mismo día (evaluando contra la misma programacion del evento)
                //IsValidateSchedule = ValidateConcurrenceIntoDayScheduleEvent(itemSchedule, lSchedule);
                IsValidateSchedule = itemSchedule.ValidateConcurrenceIntoDayScheduleEvent(itemSchedule, lSchedule);
                scheduleValidate.IsValidateConcurrenceIntoDay = IsValidateSchedule;

                //[statement] no se pueden tener más de dos eventos el mismo día (evaluando contra la programacion global de todos los eventos)
                //IsValidateSchedule = ValidateConcurrenceIntoDayScheduleEventGlobal(itemSchedule, scheduleGlobals);
                IsValidateSchedule = itemSchedule.ValidateConcurrenceIntoDayScheduleEventGlobal(itemSchedule, scheduleGlobals);
                scheduleValidate.IsValidateConcurrenceIntoDayGlobal = IsValidateSchedule;

                //[statement] No se pueden tener eventos simultáneos (evaluando contra la misma programacion del evento)
                IsValidateSchedule = itemSchedule.ValidateConcurrenceIntoHourScheduleEvent(itemSchedule, lSchedule);
                scheduleValidate.IsValidateConcurrenceIntoHour = IsValidateSchedule;

                //[statement] No se pueden tener eventos simultáneos (evaluando contra la programacion global de todos los eventos)
                //IsValidateSchedule = ValidateConcurrenceIntoHourScheduleEventGlobal(itemSchedule, scheduleGlobals);
                IsValidateSchedule = itemSchedule.ValidateConcurrenceIntoHourScheduleEventGlobal(itemSchedule, scheduleGlobals);
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
                if (!itemSchedule.IsValidPeriodDays)
                {
                    Console.WriteLine($"* Period Day is Invalid. Recomneded Date Event Between {valueMinDays} Days and {valueMaxDays} Days");
                }
                
                if (!itemSchedule.IsValidateTimeHour)
                {
                    Console.WriteLine($"* Period Time is Invalid. Recomneded Hour Event Have max {valueMaxHour} Hour");
                }
                
                if (!itemSchedule.IsValidateConcurrenceIntoDay)
                {
                    Console.WriteLine($"* Validate Date, In this event exists conflict Date. Recomneded update Date Differente {itemSchedule.InfoSchedule.DateEvent.ToShortDateString()}");
                }
                
                if (!itemSchedule.IsValidateConcurrenceIntoDayGlobal)
                {
                    Console.WriteLine($"* Validate Date, In other event exists conflict Date. Recomneded update Date Differente {itemSchedule.InfoSchedule.DateEvent.ToShortDateString()} ");
                }
                
                if (!itemSchedule.IsValidateConcurrenceIntoHour)
                {
                    Console.WriteLine($"* Validate Date and Hour, In this event exists conflict Date. Recomneded update Date and Hour Differente {itemSchedule.InfoSchedule.DateEvent.ToShortDateString()} " +
                        $"- Hour ({itemSchedule.InfoSchedule.HourInitEvent}-{itemSchedule.InfoSchedule.HourEndEvent})");
                }
                
                if (!itemSchedule.IsValidateConcurrenceIntoHourGlobal)
                {
                    Console.WriteLine($"* Validate Date and Hour, In other event exists conflict Date. Recomneded update Date and Hour Differente {itemSchedule.InfoSchedule.DateEvent.ToShortDateString()} " +
                        $"- Hour ({itemSchedule.InfoSchedule.HourInitEvent}-{itemSchedule.InfoSchedule.HourEndEvent})");
                }

            });

            return ValidSchedule;
        }
    }
}
