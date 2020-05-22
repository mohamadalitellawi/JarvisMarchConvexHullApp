using System;
using System.Collections.Generic;



namespace JarvisMarchConvexHull
{
    class Program
    {
        static void Main(string[] args)
        {
            List<JarvisMarchConvexHullLib.Point> inputData = new List<JarvisMarchConvexHullLib.Point>
            {
                new JarvisMarchConvexHullLib.Point(-7,8),
                new JarvisMarchConvexHullLib.Point(-4,6),
                new JarvisMarchConvexHullLib.Point(2,6),
                new JarvisMarchConvexHullLib.Point(6,4),
                new JarvisMarchConvexHullLib.Point(8,6),
                new JarvisMarchConvexHullLib.Point(7,-2),
                new JarvisMarchConvexHullLib.Point(4,-6),
                new JarvisMarchConvexHullLib.Point(8,-7),
                new JarvisMarchConvexHullLib.Point(0,0),
                new JarvisMarchConvexHullLib.Point (3,-2),
                new JarvisMarchConvexHullLib.Point(6,-10),
                new JarvisMarchConvexHullLib.Point(0,-6),
                new JarvisMarchConvexHullLib.Point(-9,-5),
                new JarvisMarchConvexHullLib.Point(-8,-2),
                new JarvisMarchConvexHullLib.Point(-8,0),
                new JarvisMarchConvexHullLib.Point(-10,3),
                new JarvisMarchConvexHullLib.Point(-2,2),
                new JarvisMarchConvexHullLib.Point(-10,4)
            };

            /*
             * Output − Boundary points of convex hull are −
             * (-9, -5) (6, -10) (8, -7) (8, 6) (-7, 8) (-10, 4) (-10, 3)
             */


            var results = JarvisMarchConvexHullLib.FindConvexHull(inputData);

            foreach (var item in results)
            {
                Console.WriteLine($"Point {item.x}, {item.y}");
            }

            Console.ReadKey();
        }
    }
}
