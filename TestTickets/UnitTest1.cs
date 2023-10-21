using BussinessTickets;

namespace TestTickets
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidateTimeHourSchedule()
        {
            Schedule e1 = new Schedule();
            (e1.Secuential,e1.DateEvent,e1.HourInitEvent,e1.HourEndEvent) = (1,DateTime.Now,new TimeSpan(10,0,0),new TimeSpan(16,0,0));
            bool IsValidateHour = default;
            IsValidateHour = e1.ValidateTimeHourSchedule(e1, 4);

            Assert.False(IsValidateHour);
        }
    }
}