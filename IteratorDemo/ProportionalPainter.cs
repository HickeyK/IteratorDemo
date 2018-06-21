using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorDemo
{
    class ProportionalPainter : IPainter
    {

        public TimeSpan TimePerSqMeter { get; set; }
        public double DollarsPerHour { get; set; }
        public bool IsAvailable { get; set; }

        public TimeSpan EstimateTimeToPaint(double sqMeters)
        {
            return TimeSpan.FromHours(this.TimePerSqMeter.TotalHours * sqMeters);
        }

        public double EstimateCompensation(double sqMeters)
        {
            return this.EstimateTimeToPaint(sqMeters).TotalHours * this.DollarsPerHour;
        }
    }
}
