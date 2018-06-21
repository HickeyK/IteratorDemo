using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorDemo
{
    class Painter : IPainter
    {
        public bool IsAvailable { get; set; }

        public double EstimateComp { get; set; }

        public TimeSpan EstimateTime { get; set; }


        public TimeSpan EstimateTimeToPaint(double sqMeters)
        {
            return EstimateTime;
        }

        public double EstimateCompensation(double sqMeters)
        {
            return EstimateComp;
        }
    }
}
