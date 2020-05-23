using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/**
 * @author Tushar Roy
 * Date 10/11/2107
 *
 * Convex hull or convex envelope of a set X of points in the Euclidean plane or in a Euclidean space
 * (or, more generally, in an affine space over the reals) is the smallest convex set that contains X.
 *
 * Jarvis March is finding convex or gift wrapping algorithm.
 *
 * Time complexity O(nh)
 *    n - number of points
 *    h - number of points on the boundary.
 *    Worst case O(n^2)
 *
 * Space complexity O(n^2)
 *
 * Reference
 * https://leetcode.com/problems/erect-the-fence/description/
 * https://en.wikipedia.org/wiki/Convex_hull
 * https://en.wikipedia.org/wiki/Gift_wrapping_algorithm
 */


namespace JarvisMarchConvexHull
{
    public class Point2D
    {
        public double x { get; set; }
        public double y { get; set; }
        public Point2D(double x, double y)
        {
            this.x = x; this.y = y;
        }

        public static double Distance (Point2D a , Point2D b)
        {
            double y1 = a.y - b.y;
            double x1 = a.x - b.x;
            double distance1 = Math.Sqrt(y1 * y1 + x1 * x1);
            return distance1;
        }
    }
    public class JarvisMarchConvexHullLib
    {

        public static List<Point2D> FindConvexHull(List<Point2D> points, double epsilonDistance = 0.0001)
        {
            // first find leftmost point to start march
            Point2D start = points[0];
            for (int i = 1; i < points.Count; i++)
            {
                if (points[i].x < start.x)
                {
                    start = points[i];
                }
            }

            Point2D current = start;

            // use set because this algorithm might try to insert duplicate point.
            HashSet<Point2D> result = new HashSet<Point2D>();

            result.Add(start);

            List<Point2D> collinearPoints = new List<Point2D>();

            while (true)
            {
                Point2D nextTarget = points[0];
                for (int i = 1; i < points.Count; i++)
                {
                    if (points[i] == current)
                    {
                        continue;
                    }
                    double val = CrossProduct(current, nextTarget, points[i]);
                    // if val > 0 it means points[i] is on the left of current -> nexttargett. Make him the nextTarget.
                    if (val > 0)
                    {
                        nextTarget = points[i];
                        // reset collinear points because we have new nextTarget.
                        collinearPoints = new List<Point2D>();
                    }
                    else if (val ==0)
                    {
                        // if val is 0 then collinear current, nextTarget and points[i] are collinear.
                        // if its collinear point then pick the further one but add closer one to the list of collineaar points.
                        if (DistanceCompare(current, nextTarget,points[i], epsilonDistance) < 0)
                        {
                            collinearPoints.Add(nextTarget);
                            nextTarget = points[i];
                        }
                        else
                        {
                            // just add points[i] to collinear points list. if nexttarget indeed is the next point on 
                            // convex then all points in collinear points will be also on boundary.
                            collinearPoints.Add(points[i]);
                        }
                    }
                    // else if val < 0 then nothing to do since points[i] is on right side of current -> nextTarget
                }

                // add all points in collinearpoints to result
                foreach (var item in collinearPoints)
                {
                    result.Add(item);
                }

                //if nextTarget is same as start it means we have formed an envelope and its done.
                if (nextTarget == start)
                {
                    break;
                }

                //add nextTarget to result and set current to nextTarget.
                result.Add(nextTarget);
                current = nextTarget;
            }

            return result.ToList();
        }

        /**
     * Returns < 0 if 'b' is closer to 'a' compared to 'c', 
     * == 0 if 'b' and 'c' are same distance from 'a'
     * or > 0 if 'c' is closer to 'a' compared to 'b'.
     */
        private static int DistanceCompare(Point2D a, Point2D b, Point2D c, double epsilonDistance)
        {
            double distance1 = Point2D.Distance(a, b);
            double distance2 = Point2D.Distance(a, c);

            if (Math.Abs(distance1 - distance2) < epsilonDistance)
            {
                return 0;
            }
            else if (distance1 < distance2)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }


        /**
     * Cross product to find where c belongs in reference to vector ab.
     * If result > 0 it means 'c' is on left of ab
     *    result == 0 it means 'a','b' and 'c' are collinear
     *    result < 0  it means 'c' is on right of ab
     */
        private static double CrossProduct(Point2D a, Point2D b, Point2D c)
        {
            double y1 = a.y - b.y;
            double y2 = a.y - c.y;
            double x1 = a.x - b.x;
            double x2 = a.x - c.x;
            return (y2 * x1) - (y1 * x2);
        }
    }
}

/* tested for the follwoing data
 * Input − Set of points: {(-7,8), (-4,6), (2,6), (6,4), (8,6), (7,-2), (4,-6), (8,-7),(0,0), (3,-2),(6,-10),(0,-6),(-9,-5),(-8,-2),(-8,0),(-10,3),(-2,2),(-10,4)}

Output − Boundary points of convex hull are −

(-9, -5) (6, -10) (8, -7) (8, 6) (-7, 8) (-10, 4) (-10, 3)

*/