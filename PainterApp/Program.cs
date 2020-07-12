using System;
using System.Collections.Generic;
using System.Linq;

namespace PainterApp
{
    class Program
    {
        //old code
        //private static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
        //{
        //    double bestPrice = 0;
        //    IPainter cheapest = null;

        //    foreach (IPainter painter in painters)
        //    {
        //        if (painter.IsAvailable)
        //        {
        //            double price = painter.EstimateCompensation(sqMeters);
        //            if (cheapest == null || price < bestPrice)
        //            {
        //                cheapest = painter;
        //            }

        //        }

        //    }

        //    return cheapest;
        //}

        //private static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
        //{
        //    //return painters.Where(i => i.IsAvailable)
        //    //    .OrderBy(i => i.EstimateCompensation(sqMeters))
        //    //    .FirstOrDefault();

        //    //return painters.Where(i => i.IsAvailable)
        //    //    .Aggregate((IPainter) null, (best, cur) =>
        //    //        best == null ||
        //    //        cur.EstimateCompensation(sqMeters) < best.EstimateCompensation(sqMeters)
        //    //            ? cur
        //    //            : best);


        //    return painters
        //        .Where(i => i.IsAvailable)
        //        .WithMinimum(i => i.EstimateCompensation(sqMeters));
        //}


      

        static void Main(string[] args)
        {
            IEnumerable<ProportionalPainter> painters = new List<ProportionalPainter>
            {
                new ProportionalPainter{TimePerSqMeter = new TimeSpan(1,0,0),DollarsPerHour = 200},
                new ProportionalPainter{TimePerSqMeter = new TimeSpan(1,0,0),DollarsPerHour = 100}
            };


            IPainter cheapest = CompositePainterFactories.CreateCheapestSelector(painters);
            Console.WriteLine("cheapest painter!" + cheapest.EstimateCompensation(10));

            IPainter fastest = CompositePainterFactories.CreateFastestSelector(painters);
            Console.WriteLine("Fastest painter!" + fastest.EstimateTimeToPaint(10));

            IPainter painter = CompositePainterFactories.CreateGroup(painters);
            Console.WriteLine(
                $"if they work together they complete in {painter.EstimateTimeToPaint(10)} and cost {painter.EstimateCompensation(10)}");

            Console.ReadKey();
        }
    }
}
    