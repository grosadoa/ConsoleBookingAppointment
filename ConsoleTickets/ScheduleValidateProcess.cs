using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTickets
{
    public class ScheduleValidateProcess : ISchedule
    {
        public bool ValidateConcurrenceIntoDayScheduleEvent(Schedule dataSchedule, List<Schedule> ldataSchedule)
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

        public bool ValidateConcurrenceIntoDayScheduleEventGlobal(Schedule dataSchedule, List<ScheduleGlobalValidate> ldataSchedule)
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

        public bool ValidateConcurrenceIntoHourScheduleEvent(Schedule dataSchedule, List<Schedule> ldataSchedule)
        {
            bool isValidateConcurrenceIntoHourScheduleEvent = default;

            isValidateConcurrenceIntoHourScheduleEvent = ldataSchedule.Any(aa => aa.DateEvent.ToShortDateString() == dataSchedule.DateEvent.ToShortDateString() &&
                dataSchedule.HourInitEvent >= aa.HourInitEvent && dataSchedule.HourInitEvent <= dataSchedule.HourEndEvent);

            return isValidateConcurrenceIntoHourScheduleEvent;
        }

        public bool ValidateConcurrenceIntoHourScheduleEventGlobal(Schedule dataSchedule, List<ScheduleGlobalValidate> ldataSchedule)
        {
            bool isValidateConcurrenceIntoHourScheduleEventGlobal = default;

            isValidateConcurrenceIntoHourScheduleEventGlobal = ldataSchedule.Any(aa => aa.DateEvent.ToShortDateString() == dataSchedule.DateEvent.ToShortDateString() &&
                dataSchedule.HourInitEvent >= aa.HourInitEvent && dataSchedule.HourInitEvent <= dataSchedule.HourEndEvent);

            return isValidateConcurrenceIntoHourScheduleEventGlobal;
        }

        public bool ValidatePeriodDaySchedule(Schedule dataSchedule, int minDays, int maxDays)
        {
            bool IsValidatePeriodDaySchedule = default;

            int TotalDiffDay = int.Parse($"{Math.Truncate((dataSchedule.DateEvent - DateTime.Now).TotalDays)}");

            if (minDays > TotalDiffDay && TotalDiffDay < maxDays)
            {
                IsValidatePeriodDaySchedule = true;
            }
            else
            {
                IsValidatePeriodDaySchedule = false;
            }

            return IsValidatePeriodDaySchedule;
        }

        public bool ValidateTimeHourSchedule(Schedule dataSchedule, int maxHourSchedule)
        {
            bool IsValidateTimeHour = default;

            int TotalDiffHour = int.Parse($"{(dataSchedule.HourEndEvent - dataSchedule.HourInitEvent).TotalHours}");

            if (maxHourSchedule > TotalDiffHour)
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
