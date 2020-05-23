using System;
using System.Collections.Generic;

namespace JarvisMarchConvexHull
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Point2D> inputData = new List<Point2D>
            {
                new Point2D(-7,8),
                new Point2D(-4,6),
                new Point2D(2,6),
                new Point2D(6,4),
                new Point2D(8,6),
                new Point2D(7,-2),
                new Point2D(4,-6),
                new Point2D(8,-7),
                new Point2D(0,0),
                new Point2D (3,-2),
                new Point2D(6,-10),
                new Point2D(0,-6),
                new Point2D(-9,-5),
                new Point2D(-8,-2),
                new Point2D(-8,0),
                new Point2D(-10,3),
                new Point2D(-2,2),
                new Point2D(-10,4)
            };

            /*
             * Output − Boundary points of convex hull are −
             * (-9, -5) (6, -10) (8, -7) (8, 6) (-7, 8) (-10, 4) (-10, 3)
             */


            var results = JarvisMarchConvexHullLib.FindConvexHull(inputData);

            foreach (var item in results)
            {
                Console.WriteLine($"Point \t( {item.X:f2} , {item.Y:f2} )");
            }

            Console.ReadKey();
        }
    }
}
