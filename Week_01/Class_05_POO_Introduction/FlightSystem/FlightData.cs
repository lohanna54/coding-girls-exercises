using System;

namespace Class_05_POOIntroduction.FlightSystem
{
    public class FlightData
    {
        public DateTime ScheduledDate { get; set; }

        public bool[] FilledVacancies { get; set; }

        public FlightData(DateTime scheduledDate, int maxVacancies)
        {
            ScheduledDate = scheduledDate;
            FilledVacancies = new bool[maxVacancies];
        }
    }
}
