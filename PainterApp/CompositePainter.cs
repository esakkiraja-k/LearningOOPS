using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PainterApp
{
    class CompositePainter<TPainter>:IPainter
    where TPainter:IPainter
    {
        public IEnumerable<TPainter> Painters { get; }

        public Func<double,IEnumerable<TPainter>,IPainter> Reduce { get; set; }
        public CompositePainter(IEnumerable<TPainter> painters)
        {
            this.Painters = painters.ToList();

        }
        public CompositePainter(IEnumerable<TPainter> painters, Func<double, IEnumerable<TPainter>, IPainter> reduce)
        {
            this.Painters = painters.ToList();
            this.Reduce = reduce;

        }

        //private IPainter Reduce(double sqMeters)
        //{
        //    TimeSpan time = TimeSpan.FromHours(1 / this.Painters.Where(i => i.IsAvailable)
        //                                           .Select(i => 1 / i.EstimateTimeToPaint(sqMeters).TotalHours)
        //                                           .Sum());

        //    double cost = this.Painters.Where(i => i.IsAvailable)
        //        .Select(i =>
        //            i.EstimateCompensation(sqMeters) / i.EstimateTimeToPaint(sqMeters).TotalHours * time.TotalHours)
        //        .Sum();

        //    return new ProportionalPainter()
        //    {
        //        TimePerSqMeter = TimeSpan.FromHours(time.TotalHours / sqMeters),
        //        DollarsPerHour = cost / time.TotalHours
        //    };


        //}
        public bool IsAvailable => this.Painters.Any(i => i.IsAvailable);

        public TimeSpan EstimateTimeToPaint(double sqMeters) =>
            this.Reduce(sqMeters,this.Painters).EstimateTimeToPaint(sqMeters);

        public double EstimateCompensation(double sqMeters) =>
            this.Reduce(sqMeters,this.Painters).EstimateCompensation(sqMeters);

    }
}
