using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorDemo
{
    public class Program
    {
        public static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            return painters
                .Where(painter => painter.IsAvailable)
                .WithMinimum(painter => painter.EstimateCompensation(sqMeters));

        }

        public static IPainter FindFastestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            return painters
                .Where(painter => painter.IsAvailable)
                .WithMinimum(painter => painter.EstimateTimeToPaint(sqMeters));
        }



        private static IPainter WorkTogether(double sqMeters, IEnumerable<IPainter> painters)
        {
            TimeSpan time =
                TimeSpan.FromHours(
                    1 /
                    painters
                        .Where(painter => painter.IsAvailable)
                        .Select(painter => 1 / painter.EstimateTimeToPaint(sqMeters).TotalHours)
                        .Sum());

            double cost =
                painters
                    .Where(painter => painter.IsAvailable)
                    .Select(painter =>
                        painter.EstimateCompensation(sqMeters) /
                        painter.EstimateTimeToPaint(sqMeters).TotalHours *
                        time.TotalHours)
                    .Sum();

            return new ProportionalPainter()
            {
                TimePerSqMeter = TimeSpan.FromHours(time.TotalHours / sqMeters),
                DollarsPerHour = cost / time.TotalHours
            };
        }





        static void Main(string[] args)
        {

            List<IPainter> painters = new List<IPainter>
            {
                new Painter() {EstimateComp = 100, IsAvailable = true},
                new Painter() {EstimateComp = 99, IsAvailable = true},
                new Painter() {EstimateComp = 50, IsAvailable = true},
            };

            var cheapest = FindCheapestPainter(10, painters);

            Console.Write(cheapest.EstimateCompensation(10));

        }
    }
}
