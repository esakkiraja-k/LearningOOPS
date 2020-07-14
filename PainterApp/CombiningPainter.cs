using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PainterApp
{
    class CombiningPainter<TPainter>: CompositePainter<TPainter>
    where TPainter:IPainter
    {
        private  IPaintingScheduler<TPainter> ScheduleWork
        {
            get;
        }

        public CombiningPainter(IEnumerable<TPainter> painters,
           IPaintingScheduler<TPainter> scheduler) :base(painters)
        {
            base.Reduce = this.Combine;
            this.ScheduleWork = scheduler;

        }

        private IPainter Combine(double sqMeters, IEnumerable<TPainter> painters)
        {
            IEnumerable<TPainter> availablePainters = painters.Where(i => i.IsAvailable);

            IEnumerable<PaintingTask<TPainter>> schedule = 
                this.ScheduleWork.Schedule(sqMeters, availablePainters);
            
            TimeSpan time = schedule.Max(t => t.Painter.EstimateTimeToPaint(t.SqMeters));


            double cost = schedule.Sum(t => t.Painter.EstimateCompensation(t.SqMeters));

            return new ProportionalPainter()
            {
                TimePerSqMeter = TimeSpan.FromHours(time.TotalHours / sqMeters),
                DollarsPerHour = cost / time.TotalHours
            };
        }


        //private  TimeSpan EstimateTime(double sqMeters, IEnumerable<ProportionalPainter> painters)
        //{
        //    var time = TimeSpan.FromHours(1 / painters.Where(i => i.IsAvailable)
        //                                      .Select(i => 1 / i.EstimateTimeToPaint(sqMeters).TotalHours)
        //                                      .Sum());
        //    return time;
        //}
    }
}
