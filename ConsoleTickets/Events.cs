using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTickets
{
    public class Events
    {
        public string ShortNameEvent { get; set; }
        public string FullNameEvent { get; set; }
        public DateTime DateEvent { get; set; }
        public TimeSpan HourInitEvent { get; set; }
        public TimeSpan HourEndEvent { get; set; }

    }
}
