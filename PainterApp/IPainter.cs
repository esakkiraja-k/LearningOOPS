using System;
using System.Collections.Generic;
using System.Text;

namespace PainterApp
{
    interface IPainter
    {
         bool IsAvailable { get;  }
         TimeSpan EstimateTimeToPaint(double sqMeters);
         double EstimateCompensation(double sqMeters);

    }
}
