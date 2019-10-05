using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienInvaders_ConvexHull
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Point> points = new List<Point>();
            List<Point> hull = new List<Point>();
            Point pivot = new Point(int.MaxValue, int.MaxValue);

            TextReader stdIn = Console.In;
            Console.SetIn(new StreamReader("data.txt"));

            int nA = int.Parse(Console.ReadLine());

            for (int i = 0; i < nA; i++)
            {
                string input = Console.ReadLine();
                string[] array = input.Split(' ');
                int valOne = int.Parse(array[0]);
                int valTwo = int.Parse(array[1]);
                Console.WriteLine("{0} - {1}", valOne, valTwo);
                if (pivot.X > valOne)
                {
                    if (pivot.Y > valOne)
                        pivot = new Point(valOne, valTwo);
                }
                points.Add(new Point(valOne, valTwo));
            }
            points.Sort(new RadSort(pivot));
         
                hull.Clear();
                hull.Add(pivot);
                hull.Add(points[0]);
                points.Remove(points[0]);

                while (points.Count > 0)
                {
                    hull.Add(points[0]);
                    points.Remove(points[0]);

                    while (!IsValidHull())
                    {
                        hull.Remove(hull[hull.Count - 2]);
                    }
                }
                hull.Add(pivot);
           
            for (int i = hull.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(hull[i].X + " " + hull[i].Y);
            }

            Console.SetIn(stdIn);
            Console.ReadLine();


            bool IsValidHull()
            {
                if(hull.Count < 3)
                {
                    return true;
                }

                Point a = hull[hull.Count - 3];
                Point b = hull[hull.Count - 2];
                Point c = hull[hull.Count - 1];
                int cw = a.X * b.Y - b.X * a.Y + b.X * c.Y - c.X * b.Y + c.X * a.Y - a.X * c.Y;
                return cw < 0;
            }
        }
    }
}
