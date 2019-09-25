using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienInvaders_ConvexHull
{
    class RadSort : IComparer<Point>
    {
        Point a;

        public RadSort(Point a)
        {
            this.a = a;
        }

        public int Compare(Point b, Point c)
        {
            int cw = a.X * b.Y - b.X * a.Y + b.X * c.Y - c.X * b.Y + c.X * a.Y - a.X * c.Y;
            if(cw == 0)
            {
                double d1 = GetDistTo(b);
                double d2 = GetDistTo(c);
                return d1.CompareTo(d2);
            }
            return cw;
        }

        private double GetDistTo(Point point)
        {
            int dX = point.X - a.X;
            int dY = point.Y - a.Y;
            return Math.Sqrt(dX * dX + dY * dY);
        }
    }
}
