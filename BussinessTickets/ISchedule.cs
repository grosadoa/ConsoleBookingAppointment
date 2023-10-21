using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessTickets
{
    public interface ISchedule
    {
        public bool ValidatePeriodDaySchedule(Schedule dataSchedule, int minDays, int maxDays);
        public bool ValidateTimeHourSchedule(Schedule dataSchedule, int maxHourSchedule);
        public bool ValidateConcurrenceIntoDayScheduleEvent(Schedule dataSchedule, List<Schedule> ldataSchedule);
        public bool ValidateConcurrenceIntoDayScheduleEventGlobal(Schedule dataSchedule, List<ScheduleGlobalValidate> ldataSchedule);
        public bool ValidateConcurrenceIntoHourScheduleEvent(Schedule dataSchedule, List<Schedule> ldataSchedule);
        public bool ValidateConcurrenceIntoHourScheduleEventGlobal(Schedule dataSchedule, List<ScheduleGlobalValidate> ldataSchedule);
    }
}
