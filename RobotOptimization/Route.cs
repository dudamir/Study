namespace RobotOptimization
{
    using System;
    using System.Collections.Generic;

    public class Route
    {
        private readonly List<Point> _points = new List<Point>();
        private double _routeLength;

        private Point _last;

        public void AddPoint(int x, int y)
        {
            var adding = new Point(x, y);

            if (_last != null)
            {
                _routeLength += Distance(_last, adding);
            }

            _points.Add(adding);
            _last = adding;
        }

        public void Optmize()
        {
            _routeLength = 0;
            int length = _points.Count;
            
            for (int i = 0; i < length - 1; i++)
            {
                Point current = _points[i];
                double closest = Distance(current, _points[i + 1]);

                for (int j = (i + 2); (j < length && (j - i > 1)); j++)
                {
                    double distance = Distance(current, _points[j]);

                    if (distance < closest)
                    {
                        closest = distance;
                        Swap(j, i + 1);
                    }
                }

                _routeLength += closest;
            }
        }

        private void Swap(int i, int j)
        {
            Point aux = _points[i];
            _points[i] = _points[j];
            _points[j] = aux;
        }

        private static double Distance(Point current, Point point)
        {
            double b = Math.Pow(Math.Abs(current.X - point.X), 2);
            double c = Math.Pow(Math.Abs(current.Y - point.Y), 2);
            
            return Math.Sqrt(b + c);
        }

        public void Run()
        {
            Console.WriteLine("---- START ----");

            foreach (var point in _points)
            {
                Console.WriteLine("{0} {1}", point.X, point.Y);
            }

            Console.WriteLine("full distance ran: {0}", _routeLength);
            Console.WriteLine("---- END ----");
        }

        public void ClosestPair()
        {
            var n = _points.Count;

            for (int i = 0; i < n; i++)
            {
                
            }
        }
    }
}