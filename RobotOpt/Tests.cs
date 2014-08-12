namespace RobotOptimization
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Optimize()
        {
            var route = new Route();

            route.AddPoint(1, 5);
            route.AddPoint(1, 4);
            route.AddPoint(1, 6);
            route.AddPoint(1, 3);
            route.AddPoint(1, 7);

            route.Run();

            route.Optimize();

            route.Run();
        }
    }
}
