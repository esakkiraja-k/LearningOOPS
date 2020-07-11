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

        private static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            //return painters.Where(i => i.IsAvailable)
            //    .OrderBy(i => i.EstimateCompensation(sqMeters))
            //    .FirstOrDefault();

            //return painters.Where(i => i.IsAvailable)
            //    .Aggregate((IPainter) null, (best, cur) =>
            //        best == null ||
            //        cur.EstimateCompensation(sqMeters) < best.EstimateCompensation(sqMeters)
            //            ? cur
            //            : best);


            return painters
                .Where(i => i.IsAvailable)
                .WithMinimum(i => i.EstimateCompensation(sqMeters));
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
