namespace RobotOptimization
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var route = new Route();

            route.AddPoint(1, 5);
            route.AddPoint(1, 4);
            route.AddPoint(1, 6);
            route.AddPoint(1, 3);
            route.AddPoint(1, 7);

            route.Run();

            route.ClosestPair();

            route.Run();

            Console.ReadKey();
        }
    }
}
