/* -------------------------------------------------------------------------------------------------
   Copyright (C) Siemens Healthcare GmbH 2024, All rights reserved. Restricted.
   ------------------------------------------------------------------------------------------------- */

using EvoPlanet.Simulator.Celestial;
using EvoPlanet.Simulator.Simulator;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdk.SimulatorConsole.Simulator
{
    internal class CollisionDetectorTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NonCollidingBodies_NotColliding()
        {
            var body1 = new CelestialBody(
                Vector<double>.Build.DenseOfArray(new double[] { 1.0, 10.0 }),
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

            Assert.That(isColliding, Is.True);
        }
    }
}
