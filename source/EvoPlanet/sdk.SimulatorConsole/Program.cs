using EvoPlanet.Simulator.Celestial;
using EvoPlanet.Simulator.Simulator;
using MathNet.Numerics.LinearAlgebra;

namespace sdk.SimulatorConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var body1 = new CelestialBody(
                Vector<double>.Build.DenseOfArray(new double[] { 1.0,10.0}),
                Vector<double>.Build.DenseOfArray(new double[] { 1.0, 10.0 }),
                1000,
                100);
            var body2 = new CelestialBody(
                Vector<double>.Build.DenseOfArray(new double[] { 100000.0, 10.0 }),
                Vector<double>.Build.DenseOfArray(new double[] { 1.0, 10.0 }),
                1000,
                100);
            var collisionDetector = new CollisionDetector();

            bool isColliding = collisionDetector.IsColliding(body1, body2);
            
            Console.WriteLine($"Planet pose: {isColliding}");
        }
    }
}
