/* -------------------------------------------------------------------------------------------------
   Copyright (C) Siemens Healthcare GmbH 2024, All rights reserved. Restricted.
   ------------------------------------------------------------------------------------------------- */

using EvoPlanet.Simulator.Celestial;
using MathNet.Numerics.LinearAlgebra;

namespace EvoPlanet.Simulator.Simulator
{
    public class SimulatorImpl : ISimulator
    {
        public SimulatorImpl(IGravityCalculator gravityCalculator)
        { 
            _gravityCalculator = gravityCalculator;
        }

        public void Simulate(SolarSystem system, double seconds)
        {
            // 1. Create force list
            var forceList = new List<Vector<double>>(system.CelestialBodies.Count);
            for (int i = 0; i < system.CelestialBodies.Count; i++)
            {
                forceList.Add(Vector<double>.Build.DenseOfArray(new double[] { 0.0, 0.0 }));
            }

            for (int i = 0; i < system.CelestialBodies.Count; i++)
            {
                for (int j = 0; j < system.CelestialBodies.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    // TODO: Use the inverse for the other body
                    var forceVector = _gravityCalculator.CalcForce(system.CelestialBodies[i], system.CelestialBodies[j]);
                    forceList[i] += forceVector;
                }
            }

            // 2. Apply force list over the given time (change velocity)
            for (int i = 0; i < forceList.Count; i++)
            {
                var acceleration = forceList[i] / system.CelestialBodies[i].Mass;
                system.CelestialBodies[i].Velocity += acceleration * seconds;
            }

            // 3. Move the objects according to the new velocity
            for (int i = 0; i < system.CelestialBodies.Count; i++)
            {
                system.CelestialBodies[i].Position += system.CelestialBodies[i].Velocity * seconds;
            }
        }

        private IGravityCalculator _gravityCalculator;
    }
}
