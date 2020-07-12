using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PainterApp
{
    class Painters
    {
        public IEnumerable<IPainter> ContainedPainters { get;  }

        public Painters(IEnumerable<IPainter> painters)
        {
            this.ContainedPainters = painters.ToList();
        }

        public Painters GetAvailable() => new Painters(this.ContainedPainters.Where(i => i.IsAvailable));
        

        public IPainter GetCheapestOne(double sqMeter) =>
         this.ContainedPainters.WithMinimum(i => i.EstimateCompensation(sqMeter));

        public IPainter GetFastestOne(double sqMeter) =>
            this.ContainedPainters.WithMinimum(i => i.EstimateTimeToPaint(sqMeter));

    }
}
