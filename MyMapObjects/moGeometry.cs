using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMapObjects
{
    public abstract class moGeometry:moShape
    {

        // 抽象方法定义
        public abstract moRectangle GetEnvelope();
        public abstract bool Intersect(moRectangle rect);
    }
}
