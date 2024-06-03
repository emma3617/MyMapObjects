using System;

namespace MyMapObjects
{
    public class moPoint : moGeometry
    {
        #region 字段

        private double _X;
        private double _Y;

        #endregion

        #region 构造函数

        public moPoint() { }

        public moPoint(double x, double y)
        {
            _X = x;
            _Y = y;
        }

        #endregion

        #region 属性

        /// <summary>
        /// 获取或设置X坐标
        /// </summary>
        public double X
        {
            get { return _X; }
            set { _X = value; }
        }

        /// <summary>
        /// 获取或设置Y坐标
        /// </summary>
        public double Y
        {
            get { return _Y; }
            set { _Y = value; }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 获取外包矩形
        /// </summary>
        /// <returns></returns>
        public override moRectangle GetEnvelope()
        {
            // 点的包络矩形即点本身
            return new moRectangle(_X, _X, _Y, _Y);
        }

        /// <summary>
        /// 判断是否与矩形相交
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        public override bool Intersect(moRectangle rect)
        {
            // 点与矩形相交的条件是点在矩形范围内
            return _X >= rect.MinX && _X <= rect.MaxX && _Y >= rect.MinY && _Y <= rect.MaxY;
        }

        /// <summary>
        /// 复制
        /// </summary>
        /// <returns></returns>
        public moPoint Clone()
        {
            return new moPoint(_X, _Y);
        }

        /// <summary>
        /// 计算两点之间的距离
        /// </summary>
        /// <param name="otherPoint"></param>
        /// <returns></returns>
        public double Distance(moPoint otherPoint)
        {
            double deltaX = this.X - otherPoint.X;
            double deltaY = this.Y - otherPoint.Y;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        #endregion
    }
}
