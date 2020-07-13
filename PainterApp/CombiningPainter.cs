using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PainterApp
{
    class CombiningPainter:CompositePainter<ProportionalPainter>
    {
        public CombiningPainter(IEnumerable<ProportionalPainter> painters):base(painters)
        {
            base.Reduce = this.Combine;

        }

        private IPainter Combine(double sqMeters, IEnumerable<ProportionalPainter> painters)
        {
            TimeSpan time = EstimateTime(sqMeters, painters);

            double cost = painters.Where(i => i.IsAvailable)
                .Select(i =>
                    i.EstimateCompensation(sqMeters) / i.EstimateTimeToPaint(sqMeters).TotalHours * time.TotalHours)
                .Sum();

            return new ProportionalPainter()
            {
                TimePerSqMeter = TimeSpan.FromHours(time.TotalHours / sqMeters),
                DollarsPerHour = cost / time.TotalHours
            };
        }

        public Func<double, IEnumerable<ProportionalPainter>,TimeSpan> EstimateTime { get; set; }

        //private  TimeSpan EstimateTime(double sqMeters, IEnumerable<ProportionalPainter> painters)
        //{
        //    var time = TimeSpan.FromHours(1 / painters.Where(i => i.IsAvailable)
        //                                      .Select(i => 1 / i.EstimateTimeToPaint(sqMeters).TotalHours)
        //                                      .Sum());
        //    return time;
        //}
    }
}
