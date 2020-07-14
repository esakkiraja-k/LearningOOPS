using System;
using System.Collections.Generic;
using System.Text;

namespace PainterApp
{
    class PaintingTask<TPainter> where TPainter :IPainter
    {
        public TPainter Painter { get;  }
        public double SqMeters { get; set; }

        public PaintingTask(TPainter painter,double sqmeters)
        {
            this.Painter = painter;
            this.SqMeters = sqmeters;

        }
    }
}
